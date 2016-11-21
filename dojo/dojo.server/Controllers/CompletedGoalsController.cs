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
    public class CompletedGoalsController : ApiController
    {
        private string connectionString;

        private const string GetSql = @"
            SELECT Points, Reason
            FROM [CompletedGoals]
            WHERE USERID = @UserId
            ORDER BY Updated desc";

        private const string InsertSql = @"
            INSERT INTO [dbo].[CompletedGoals]
           ([Id]
           ,[Points]
           ,[Reason]
            ,UserId, Updated)
     VALUES
           (NEWID()
           ,@Points
           ,@Reason
            ,@UserId
            , GETDATE())";

        public CompletedGoalsController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }
        public IEnumerable<CompletedGoal> GetCompletedGoals(string Id)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var results =
                    conn.Query(GetSql, new { UserId = Id })
                        .Select(
                            row =>
                                new CompletedGoal
                                {
                                    Points = row.Points,
                                    Reason= row.Reason,
                                })
                        .ToArray();
                return results;
            }
        }

        public HttpResponseMessage PostCompletedGoal(string Id, [FromBody]CompletedGoal goal)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            InsertSql,
                            new
                            {
                                UserId = Id,
                                Points = goal.Points,
                                Reason = goal.Reason
                            });
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
