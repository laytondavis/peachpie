using System;
using System.Collections.Generic;
using System.Text;
using Pchp.Core;
using Pchp.Library.Streams;

namespace Peachpie.Library.Network
{
    static class SocketFunctions
    {

        #region pfsockopen

        [return: CastToFalse]
        public static PhpResource pfsockopen(Context ctx, string target, int port)
        {
            int errno;
            string errstr;
            return fsockopen(ctx, target, port, out errno, out errstr, ctx.Configuration.Core.DefaultSocketTimeout, true);
        }

        [return: CastToFalse]
        public static PhpResource pfsockopen(Context ctx, string target, int port, out int errno)
        {
            string errstr;
            return fsockopen(ctx, target, port, out errno, out errstr, ctx.Configuration.Core.DefaultSocketTimeout, true);
        }

        [return: CastToFalse]
        public static PhpResource pfsockopen(Context ctx, string target, int port, out int errno, out string errstr)
        {
            return fsockopen(ctx, target, port, out errno, out errstr, ctx.Configuration.Core.DefaultSocketTimeout, true);
        }

        [return: CastToFalse]
        public static PhpResource pfsockopen(Context ctx, string target, int port, out int errno, out string errstr, double timeout)
        {
            return fsockopen(ctx, target, port, out errno, out errstr, timeout, true);
        }

        #endregion

        #region fsockopen

        public static PhpResource fsockopen(Context ctx, string target, int port)
        {
            int errno;
            string errstr;
            return fsockopen(ctx, target, port, out errno, out errstr);
        }

        public static PhpResource fsockopen(Context ctx, string target, int port, out int errno)
        {
            string errstr;
            return fsockopen(ctx, target, port, out errno, out errstr, ctx.Configuration.Core.DefaultSocketTimeout, false);
        }

        public static PhpResource fsockopen(Context ctx, string target, int port, out int errno, out string errstr)
        {
            return fsockopen(ctx, target, port, out errno, out errstr, ctx.Configuration.Core.DefaultSocketTimeout, false);
        }

        public static PhpResource fsockopen(Context ctx, string target, int port, out int errno, out string errstr, double timeout, bool persistent = false)
        {
            return StreamSocket.Connect(ctx, target, port, out errno, out errstr, timeout,
              persistent ? StreamSocket.SocketOptions.Persistent : StreamSocket.SocketOptions.None,
              StreamContext.Default);
        }

        #endregion

        #region socket_get_status, socket_set_blocking, socket_set_timeout

        /// <summary>
        /// Gets status.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <returns>The array containing status info.</returns>
        public static PhpArray socket_get_status(PhpResource stream)
        {
            return PhpStreams.stream_get_meta_data(stream);
        }

        /// <summary>
        /// Sets blocking mode.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="mode">A mode.</param>
        public static bool socket_set_blocking(PhpResource stream, int mode)
        {
            return PhpStreams.stream_set_blocking(stream, mode);
        }


        /// <summary>
        /// Sets a timeout.
        /// </summary>
        /// <param name="stream">A stream.</param>
        /// <param name="seconds">Seconds part of the timeout.</param>
        /// <param name="microseconds">Microseconds part of the timeout.</param>
        public static bool socket_set_timeout(PhpResource stream, int seconds, int microseconds = 0)
        {
            return PhpStreams.stream_set_timeout(stream, seconds, microseconds);
        }

        #endregion
    }
}
