using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dojo.server.Models;
using Dapper;

namespace dojo.server.Controllers
{
    public class OverviewController : ApiController
    {
        private string connectionString;

        private const string GetScore = @"
            SELECT Score, Target, DaysRemaining
            FROM Overview
            WHERE UserId = @UserId";

        private const string InsertSql = @"
            INSERT INTO [dbo].[Overview]
           ([Id]
           ,[Score]
           ,[Target]
           ,[DaysRemaining]
           ,[Updated]
           ,[UserId])
     VALUES
           (NEWID()
           ,100
           ,600
           ,32
           ,GETDATE()
           ,@UserId)";

        private const string InsertGoalsSql = @"
            INSERT INTO [dbo].[Goals]
           ([Id]
           ,[Points]
           ,[Target]
           ,[Reason]
           ,[UserId]
           ,[Updated])
     VALUES
           (NEWID()
           ,29
           ,100
           ,'Deposit £200 into your ISA'
           ,@UserId, GETDATE()),
(NEWID()
           ,45
           ,100
           ,'Pay off £500 this month on your credit card'
           ,@UserId, GETDATE()),
(NEWID()
           ,17
           ,100
           ,'Spend less than £100 this month on clothes'
           ,@UserId, GETDATE()),
(NEWID()
           ,87
           ,100
           ,'Spend less than £50 at restaurants this week '
           ,@UserId, GETDATE())";

        private const string InsertCompletedGoalsSql = @"
            INSERT INTO [dbo].[CompletedGoals]
           ([Id]
           ,[Points]
           ,[Reason]
           ,[UserId]
           ,[Updated])
     VALUES
           (NEWID()
           ,5
           ,'Repaid £70 on your mortgage'
           ,@UserId, GETDATE()),
(NEWID()
           ,20
           ,'Paid off one of your credit cards'
           ,@UserId, GETDATE()),
(NEWID()
           ,30
           ,'You received 30 points for completing the training'
           ,@UserId, GETDATE()),
(NEWID()
           ,3
           ,'Cut your groceries bill by £10 compared to last week'
           ,@UserId, GETDATE()),
(NEWID()
           ,1
           ,'Answerd spending question correctly'
           ,@UserId, GETDATE()),
(NEWID()
           ,8
           ,'Cut your electricity bill by £18'
           ,@UserId, GETDATE()),
(NEWID()
           ,10
           ,'Save £300 last month'
           ,@UserId, GETDATE()),
(NEWID()
           ,1
           ,'Completed spending training'
           ,@UserId, GETDATE()),
(NEWID()
           ,2
           ,'Only ate out once last week'
           ,@UserId, GETDATE())";

        private const string UpdateScore = @"
            UPDATE Overview
            SET Score = Score + @Amount,
                Updated = GETDATE()
            WHERE UserId = @UserId";

        public OverviewController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }
        public DojoOverview GetOverview(string Id)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var overview =
                    conn.Query(GetScore, new { UserId = Id})
                        .Select(
                            row =>
                                new DojoOverview
                                {
                                    Score = row.Score,
                                    Target = row.Target,
                                    DaysRemaining = row.DaysRemaining
                                })
                        .FirstOrDefault();

                if (overview == null)
                {
                    conn.Execute(
                            InsertSql,
                            new
                            {
                                UserId = Id
                            });

                    conn.Execute(
                            InsertGoalsSql,
                            new
                            {
                                UserId = Id
                            });

                    conn.Execute(
                            InsertCompletedGoalsSql,
                            new
                            {
                                UserId = Id
                            });
                }

                overview =
                    conn.Query(GetScore, new { UserId = Id })
                        .Select(
                            row =>
                                new DojoOverview
                                {
                                    Score = row.Score,
                                    Target = row.Target,
                                    DaysRemaining = row.DaysRemaining
                                })
                        .First();
                return overview;
            }
        }

        public DojoOverview PostScore(string Id, [FromBody]int amount)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            UpdateScore,
                            new
                            {
                                UserId = Id,
                                Amount = amount
                            });

                var overview =
                    conn.Query(GetScore, new { UserId = Id })
                        .Select(
                            row =>
                                new DojoOverview
                                {
                                    Score = row.Score,
                                    Target = row.Target,
                                    DaysRemaining = row.DaysRemaining
                                })
                        .First();
                return overview;
            }
        }
    }
}
