using Pchp.Core;
using Pchp.Library.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peachpie.Library.Postgres
{
    internal class PostgresConnectionManager : ConnectionManager<PostgresqlConnectionResource>
    {
        /// <summary>
        /// Gets the manager singleton within runtime context.
        /// </summary>
        public static PostgresConnectionManager GetInstance(Context ctx) => ctx.GetStatic<PostgresConnectionManager>();

        protected override PostgresqlConnectionResource CreateConnection(string connectionString)
        {
            var ans = new PostgresqlConnectionResource(this, connectionString);
            return ans;
        }
    }
}
