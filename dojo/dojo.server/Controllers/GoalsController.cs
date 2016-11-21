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
            FROM [Goals]
            WHERE UserId = @UserId
            ORDER BY [Updated] desc";

        private const string InsertSql = @"
            INSERT INTO [Goals]
           ([Id]
           ,[Points]
           ,[Target]
           ,[Reason]
            ,[UserId], Updated)
     VALUES
           (NEWID()
           ,0
           ,@Target
           ,@Reason
           ,@UserId, GETDATE())";

        public GoalsController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }

        public IEnumerable<Goal> GetGoals(string Id)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var results =
                    conn.Query(GetSql, new { UserId = Id })
                        .Select(
                            row =>
                                new Goal
                                {
                                    Points = row.Points,
                                    Target = row.Target,
                                    Reason= row.Reason,
                                    Percentage = (int)((decimal)row.Points / (decimal)row.Target * 100)
                                })
                        .ToArray();
                return results;
            }
        }

        public HttpResponseMessage PostGoal(string Id, [FromBody]Goal goal)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            InsertSql,
                            new
                            {
                                UserId = Id,
                                Target = goal.Target,
                                Reason = goal.Reason,
                            });
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
