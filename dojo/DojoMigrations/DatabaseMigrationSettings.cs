using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DojoMigrations
{
    public class DatabaseMigrationSettings
    {
        public const string SchemaScriptsFolder = "DojoMigrations.Schema";

        public static Assembly ScriptsAssembly => typeof(DatabaseMigrationSettings).Assembly;
    }
}
