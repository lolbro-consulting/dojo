using System.Configuration;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using DojoMigrations;

namespace SchemaMigrator
{
    class Program
    {
        private static void Main(string[] args)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var connectionString = ConfigurationManager.ConnectionStrings["Migrator"].ConnectionString;

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(
                    DatabaseMigrationSettings.ScriptsAssembly,
                    script => script.StartsWith(DatabaseMigrationSettings.SchemaScriptsFolder))
                .LogToConsole()
                .Build();

            DatabaseUpgradeResult result;

            result = upgrader.PerformUpgrade();
            result.Scripts.ToList();
        }
    }
}
