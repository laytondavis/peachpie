﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Pchp.Core;
using Pchp.Library.Streams;

namespace Peachpie.Library.Network
{
    /// <summary>
    /// CURL resource.
    /// </summary>
    public sealed class CURLResource : PhpResource
    {
        #region Properties

        public string Url { get; set; }

        public string DefaultSheme { get; set; } = "http";

        public bool FollowLocation { get; set; } = false;

        public int MaxRedirects { get; set; } = 50;

        /// <summary>
        /// The contents of the "User-Agent: " header to be used in a HTTP request.
        /// </summary>
        public string UserAgent { get; set; }

        public string Referer { get; set; }

        public string Method { get; set; } = WebRequestMethods.Http.Get;

        /// <summary>
        /// The full data to post in a HTTP "POST" operation.
        /// This parameter can either be passed as a urlencoded string like 'para1=val1&amp;para2=val2&amp;...' or as an array with the field name as key and field data as value.
        /// If value is an array, the Content-Type header will be set to multipart/form-data.
        /// </summary>
        public PhpValue PostFields { get; set; } = PhpValue.Void;

        /// <summary>
        /// Headers to be send with the request.
        /// Keys of the array are ignored, values are in form of <c>header-name: value</c>
        /// </summary>
        public PhpArray Headers { get; set; }

        /// <summary>
        /// The value of the Cookie header.
        /// Ignored if already present in <see cref="Headers"/>.
        /// </summary>
        public string CookieHeader { get; set; }

        /// <summary>
        /// As long as <see cref="CURLConstants.CURLOPT_COOKIEFILE"/> is set (regardless of the value, even
        /// null suffices), the cookies retrieved from the server are recorded.
        /// </summary>
        public bool CookieFileSet { get; set; } = false;

        public bool ReturnTransfer { get; set; } = false;

        /// <summary>
        /// <c>true</c> to include the header in the output.
        /// Default is <c>false</c>.
        /// </summary>
        public bool OutputHeader { get; set; } = false;

        /// <summary>
        /// The file that the transfer should be written to.
        /// </summary>
        public PhpStream OutputTransfer { get; set; }

        /// <summary>
        /// The file that the transfer should be read from when uploading using <c>PUT</c> method.
        /// </summary>
        public PhpStream PutStream { get; set; }

        /// <summary>
        /// Private data set to the handle.
        /// </summary>
        internal PhpValue Private { get; set; }

        #endregion

        internal DateTime StartTime { get; set; }

        /// <summary>
        /// Ongoing request handled by the framework. Must be set to null after being processed.
        /// </summary>
        internal Task<WebResponse> ResponseTask { get; set; }

        /// <summary>
        /// Response after the execution.
        /// </summary>
        internal CURLResponse Result { get; set; }

        public CURLResource() : base(CURLConstants.CurlResourceName)
        {
        }

        protected override void FreeManaged()
        {
            // clear references
            this.Result = null;
            this.OutputTransfer = null;
            this.PutStream = null;
            this.Headers = null;
            this.PostFields = PhpValue.Void;

            //
            base.FreeManaged();
        }
    }

    sealed class CURLResponse
    {
        /// <summary>
        /// Error code number if exception happened.
        /// </summary>
        public CurlErrors ErrorCode { get; set; } = CurlErrors.CURLE_OK;

        /// <summary>
        /// Optional. Error message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets value indicating the request errored.
        /// </summary>
        public bool HasError => ErrorCode != CURLConstants.CURLE_OK;

        public Uri ResponseUri { get; }

        public HttpStatusCode StatusCode { get; }

        public DateTime LastModified
        {
            get
            {
                if (DateTime.TryParse(Headers?[HttpRequestHeader.LastModified], out var dt))
                {
                    return dt;
                }
                else
                {
                    return DateTime.UtcNow;
                }
            }
        }

        /// <summary>
        /// Content length of download, read from Content-Length: field.
        /// </summary>
        public long ContentLength => Headers != null && long.TryParse(Headers[HttpRequestHeader.ContentLength], out var length) ? length : -1;

        public string ContentType => (Headers != null) ? Headers[HttpRequestHeader.ContentType] : string.Empty;

        public int HeaderSize => (Headers != null) ? Headers.ToByteArray().Length : 0;

        public WebHeaderCollection Headers { get; }

        public CookieCollection Cookies { get; }

        public TimeSpan TotalTime { get; set; }

        /// <summary>
        /// Private data set to the requesting handle.
        /// </summary>
        public PhpValue Private { get; set; }

        public PhpValue ExecValue { get; }

        public static CURLResponse CreateError(CurlErrors errcode, Exception ex = null) => new CURLResponse(PhpValue.False) { ErrorCode = errcode, ErrorMessage = ex?.Message };

        public CURLResponse(PhpValue execvalue, HttpWebResponse response = null)
        {
            this.ExecValue = execvalue;

            if (response != null)
            {
                this.ResponseUri = response.ResponseUri;
                this.StatusCode = response.StatusCode;
                this.Headers = response.Headers;
                this.Cookies = response.Cookies;
            }
        }
    }
}
