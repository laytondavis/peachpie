using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Peachpie.Web
{
    /// <summary>
    /// <see cref="TextWriter"/> implementation passing text to underlaying response stream in given encoding.
    /// </summary>
    sealed class ResponseTextWriter : TextWriter
    {
        readonly Stream _responseStream;
        readonly Encoding _encoding;

        public ResponseTextWriter(Stream responseStream, Encoding encoding)
        {
            Debug.Assert(responseStream != null);
            Debug.Assert(encoding != null);

            _responseStream = responseStream;
            _encoding = encoding;
        }

        public override Encoding Encoding => _encoding;

        public override void Write(string value)
        {
            // TODO: optimize, do not allocate byte array over and over

            var bytes = _encoding.GetBytes(value);
            _responseStream.Write(bytes, 0, bytes.Length);
        }

        public override void Write(char value)
        {
            Write(value.ToString());
        }
    }
}
