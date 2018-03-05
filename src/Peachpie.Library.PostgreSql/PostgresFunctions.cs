using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Pchp;
using Pchp.Core;
using Pchp.Library.Resources;
using Npgsql;

namespace Peachpie.Library.Postgres
{
    /// <summary>
    ///  Postgres Functions container
    /// </summary>
    [PhpExtension("Postgres", Registrator = typeof(Registrator))]
    public static class Postgres
    {
        sealed class Registrator
        {
            public Registrator()
            {
                // will fill this in later
                // this class sets up global PHP configuration stuff
                Context.RegisterConfiguration(new PostgresConfiguration());
                PostgresConfiguration.RegisterLegacyOptions();
            }
        }

        #region utils
        static PostgresqlConnectionResource LastConnection(Context ctx) => PostgresConnectionManager.GetInstance(ctx).GetLastConnection();

        static PostgresqlConnectionResource ValidConnection(Context ctx, PhpResource link)
        {
            var resource = link ?? LastConnection(ctx);
            if (resource is PostgresqlConnectionResource)
            {
                return (PostgresqlConnectionResource)resource;
            }
            else
            {
                PhpException.Throw(PhpError.Warning, Resources.invalid_connection_resource);
                return null;
            }
        }
        #endregion

        #region pg_connect
        /// <summary>
        ///   open a connection to a postgres database
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="connstring">postgres connection string</param>
        /// <param name="conType"></param>
        /// <returns>php resource that links to the connection</returns>
        // [return: CastToFalse]
        public static PhpResource pg_connect(Context ctx, string connstring, int conType = 0)
        {
            bool new_link = true;
            if (conType != 0)
            {
                new_link = false;
            }
            var config = ctx.Configuration.Get<PostgresConfiguration>();
            Debug.Assert(config != null);

            bool success;
            var inst = PostgresConnectionManager.GetInstance(ctx);
            PostgresqlConnectionResource connection = null;
            connection = inst.CreateConnection(connstring, new_link, -1, out success);

            if (!success)
            {
                connection = null;
            }

            return connection;
        }
        #endregion

        #region pg_query
        /// <summary>
        ///   pass a query to postgres
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="connection">php connection resource ID</param>
        /// <param name="query">query string</param>
        /// <returns></returns>
        public static PhpResource pg_query(Context ctx, PhpResource link, PhpString query)
        {
            var connection = ValidConnection(ctx, link);
            if (connection == null || query.IsEmpty)
            {
                return null;
            }
            else
            {
                // standard unicode behaviour
                return connection.ExecuteQuery(query.ToString(ctx), true);
            }
        }
        public static PhpResource pg_query(Context ctx, PhpString query)
        {
            // have to look up last used connection
            var connection = ValidConnection(ctx, null);
            return pg_query(ctx, connection, query);
        }

        /// <summary>
        ///  pass a parameterized query to postgres
        /// </summary>
        /// <param name="ctx"> peachpie context</param>
        /// <param name="connection">optional connection resource</param>
        /// <param name="query">query to pass on to postgres</param>
        /// <param name="parms">parameter array</param>
        /// <returns>php context that links to the return results</returns>
        public static PhpResource pg_query_params(Context ctx, PhpResource link, PhpString query, PhpValue parms)
        {
            var connection = ValidConnection(ctx, link);
            string qrystr = fixQuery(query);
            List<IDataParameter> parm;
            IEnumerable<IDataParameter> pgi = new NpgsqlParameter[] { };
            parm = pgi.ToList<IDataParameter>();
            PhpArray parmList = (PhpArray)parms;
            for (int idx = 0; idx < parmList.Count; idx++)
            {
                var pnum = idx + 1;
                parm.Add(pgparms(pnum.ToString(), parmList[idx]));
            }

            if (connection == null || query.IsEmpty)
            {
                return null;
            }
            else
            {
                // standard unicode behaviour
                return connection.ExecuteCommand(qrystr, System.Data.CommandType.Text, true, parm, false);
            }
        }
        public static PhpResource pg_query_params(Context ctx, PhpString query, PhpValue parms)
        {
            // look up connection from last referenced 
            var connection = ValidConnection(ctx, null);
            return pg_query_params(ctx, connection, query, parms);
        }

        /// <summary>
        ///   change parameter markers from $<number> to :<number>
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        private static string fixQuery(PhpString qry)
        {
            string tqry = qry.ToString();
            while (tqry.IndexOf('$') >= 0)
            {
                int idx = tqry.IndexOf('$');
                tqry = tqry.Substring(0, idx) + ":" + tqry.Substring(idx + 1);
            }
            return tqry;
        }
        /// <summary>
        /// create a 
        /// </summary>
        /// <param name="pname">parameter name(number)</param>
        /// <param name="parms">parameter value</param>
        /// <returns>postgres parameter</returns>
        private static NpgsqlParameter pgparms(string pname, PhpValue parms)
        {
            NpgsqlParameter pgprm = new NpgsqlParameter();
            pgprm.ParameterName = pname;
            pgprm.Value = parms.ToString();
            return pgprm;
        }
        #endregion

        #region pg_num_rows
        /// <summary>
        ///   reuturn number of rows affected by query result resource
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="resource">resource of last query</param>
        /// <returns></returns>
        public static int pg_num_rows(Context ctx, PhpResource resource)
        {
            var result = PostgresResultResource.ValidResult(resource);
            if (result == null)
                return 0;

            return result.ResultSetCount;
        }
        #endregion

        #region pg_fetch_row
        /// <summary>
        /// return row out of result set
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="resource">php resource id that has result set</param>
        /// <param name="rownum">optional row number to return</param>
        /// <returns>array form of record</returns>
        //[return: CastToFalse]
        public static PhpArray pg_fetch_row(Context ctx, PhpResource resource, int rownum = 0)
        {
            var result = PostgresResultResource.ValidResult(resource);
            if (result == null)
                return null;

            if (rownum != 0)
            {
                result.SeekRow(rownum);
            }
            return result.FetchArray(true, false);
        }
        #endregion

        #region pg_fetch_object
        /// <summary>
        /// fetch postgres result record as object
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="resource">query result resource</param>
        /// <param name="row">optional row to fetch</param>
        /// <param name="className">optional class to instantiate and pass record to</param>
        /// <param name="parms">optional parameters to pass to class</param>
        /// <returns>the record found -- or false if there is no record</returns>
        //[return: CastToFalse]
        public static object pg_fetch_object(Context ctx, PhpResource resource, int row = 0, string className = null, PhpArray parms = null)
        {
            // still need to support the class instantiation. I know I don't use this feature
            var result = PostgresResultResource.ValidResult(resource);
            if (result == null)
                return null;

            if (row != 0)
            {
                result.SeekRow(row);
            }
            return result.FetchStdClass();
        }
        #endregion

        #region pg_fetch_result
        /// <summary>
        /// return a field out of the result set
        /// </summary>
        /// <param name="ctx">peachpie context</param>
        /// <param name="resource">php resource Id for the result set</param>
        /// <param name="row">row number of the result set to use</param>
        /// <param name="field">field name or number to return</param>
        /// <returns>value of the field or column</returns>
        [return: CastToFalse]
        public static object pg_fetch_result(Context ctx, PhpResource resource, int row, PhpValue field)
        {
            var result = PostgresResultResource.ValidResult(resource);
            if (result == null)
                return null;

            if (field.IsInteger())
            {
                return result.GetFieldValue(row, (int)field);
            }
            else
            {
                return result.GetFieldValue(row, field.ToString(ctx));
            }
        }
        public static object pg_fetch_result(Context ctx, PhpResource resource, PhpValue field)
        {
            // find the current row from the resource
            int row = 0;
            return pg_fetch_result(ctx, resource, row, field);
        }
        #endregion

        #region pg_close
        /// <summary>
        /// close postgres connection
        /// </summary>
        /// <param name="connection">optional connection to close</param>
        /// <returns>true of closed connection/false if failed</returns>
        public static bool pg_close(Context ctx, PhpResource connection = null)
        {
            var conn = ValidConnection(ctx, connection);
            if (conn != null)
            {
                conn.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}