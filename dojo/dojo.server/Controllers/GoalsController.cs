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
    public class GoalsController : ApiController
    {
        private string connectionString;

        private const string GetSql = @"
            SELECT Points, Target, Reason
            FROM [Goal]";

        private const string InsertSql = @"
            INSERT INTO [Goal]
           ([Id]
           ,[Amount]
           ,[Target]
           ,[Reason])
     VALUES
           (NEWID()
           ,0
           ,@Target
           ,@Reason)";

        public GoalsController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }
        public IEnumerable<Goal> GetGoals()
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var results =
                    conn.Query(GetSql)
                        .Select(
                            row =>
                                new Goal
                                {
                                    Points = row.Points,
                                    Target = row.Target,
                                    Reason= row.Reason,
                                })
                        .ToArray();
                return results;
            }
        }

        public HttpResponseMessage PostGoal([FromBody]Goal goal)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            InsertSql,
                            new
                            {
                                Target = goal.Target,
                                Reason = goal.Reason,
                            });
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
