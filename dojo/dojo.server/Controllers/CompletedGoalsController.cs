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
            FROM [CompletedGoals]";

        private const string InsertSql = @"
            INSERT INTO [dbo].[CompletedGoals]
           ([Id]
           ,[Points]
           ,[Reason])
     VALUES
           (NEWID()
           ,@Points
           ,@Reason)";

        public CompletedGoalsController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }
        public IEnumerable<CompletedGoal> GetCompletedGoals()
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var results =
                    conn.Query(GetSql)
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

        public HttpResponseMessage PostCompletedGoal([FromBody]CompletedGoal goal)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            InsertSql,
                            new
                            {
                                Points = goal.Points,
                                Reason = goal.Reason
                            });
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
