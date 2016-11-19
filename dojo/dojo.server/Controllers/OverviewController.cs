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
            SELECT Score
            FROM Overview";

        private const string UpdateScore = @"
            UPDATE Overview
            SET Score = Score + @Amount,
                Updated = GETDATE()";

        public OverviewController()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Dojo"].ConnectionString;
        }
        public DojoOverview GetOverview()
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                var overview =
                    conn.Query(GetScore)
                        .Select(
                            row =>
                                new DojoOverview
                                {
                                    Score = row.Score
                                })
                        .First();
                return overview;
            }
        }

        public HttpResponseMessage PostScore([FromBody]int amount)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Execute(
                            UpdateScore,
                            new
                            {
                                Amount = amount
                            });
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
