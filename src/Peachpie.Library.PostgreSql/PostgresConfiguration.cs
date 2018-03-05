using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using static Pchp.Library.StandardPhpOptions;

namespace Peachpie.Library.Postgres
{
    sealed class PostgresConfiguration : IPhpConfiguration
    {
        IPhpConfiguration IPhpConfiguration.Copy() => (PostgresConfiguration)this.MemberwiseClone();

        public string ExtensionName => "postgres";

        /// <summary>
        /// Request timeout in seconds. Non-positive value means no timeout.
        /// </summary>
        public int ConnectTimeout = 0;

        /// <summary>
        /// <c>Maximum Pool Size</c> value passed to the MySql Connector/Net Connection String.
        /// </summary>
        public int MaxPoolSize = 100;

        /// <summary>
        /// Command timeout, in seconds.
        /// </summary>
        public int DefaultCommandTimeout = -1;

        /// <summary>
        /// Default server (host) name.
        /// </summary>
        public string Server = "localhost";

        /// <summary>
        /// Default port.
        /// </summary>
        public int Port = 3306;

        /// <summary>
        /// Default user name.
        /// </summary>
        public string User = "root";

        /// <summary>
        /// Default password.
        /// </summary>
        public string Password = "";

        /// <summary>
        /// If not <c>null</c> reference, this connection string is used by parameterless <c>mysql_connect()</c> function call as MySql Connector/.NET connection string.
        /// </summary>
        internal string ConnectionString = null;

        /// <summary>
        /// Maximum number of connections per request. Negative value means no limit.
        /// </summary>
        public int MaxConnections = -1;

        /// <summary>
        /// Gets, sets, or restores a value of a legacy configuration option.
        /// </summary>
        static PhpValue GetSet(Context ctx, IPhpConfigurationService config, string option, PhpValue value, IniAction action)
        {
            var local = config.Get<PostgresConfiguration>();

            switch (option)
            {
                // local:

                case "postgres.connect_timeout":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.ConnectTimeout, 0, value, action);
                case "postgres.default_port":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.Port, 3306, value, action);
                case "postgres.default_host":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.Server, null, value, action);
                case "postgres.default_user":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.User, "root", value, action);
                case "postgres.default_password":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.Password, "", value, action);
                case "postgres.default_command_timeout":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.DefaultCommandTimeout, -1, value, action);
                case "postgres.connection_string":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.ConnectionString, null, value, action);

                // global:

                case "postgres.max_links":
                    Debug.Assert(action == IniAction.Get);
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.MaxConnections, -1, value, action);
                case "postgres.max_pool_size":
                    return (PhpValue)Pchp.Library.StandardPhpOptions.GetSet(ref local.MaxPoolSize, 100, value, action);
            }

            Debug.Fail("Option '" + option + "' is supported but not implemented.");
            return PhpValue.Null;
        }

        /// <summary>
        /// Registers legacy ini-options.
        /// </summary>
        internal static void RegisterLegacyOptions()
        {
            const string s = "postgres";
            var d = new GetSetDelegate(GetSet);

            // local:
            Register("postgres.trace_mode", IniFlags.Unsupported | IniFlags.Local, d, s);
            Register("postgres.default_port", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.default_socket", IniFlags.Unsupported | IniFlags.Local, d, s);
            Register("postgres.default_host", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.default_user", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.default_password", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.connect_timeout", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.default_command_timeout", IniFlags.Supported | IniFlags.Local, d, s);
            Register("postgres.connection_string", IniFlags.Supported | IniFlags.Local, d, s);

            // global:
            Register("postgres.allow_persistent", IniFlags.Unsupported | IniFlags.Global, d, s);
            Register("postgres.max_persistent", IniFlags.Unsupported | IniFlags.Global, d, s);
            Register("postgres.max_links", IniFlags.Supported | IniFlags.Global, d, s);
            Register("postgres.max_pool_size", IniFlags.Supported | IniFlags.Global, d, s);
        }
    }
}
