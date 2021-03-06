﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Pchp.Core;
using Pchp.Library.Streams;

namespace Peachpie.Library.Network
{
    [PhpExtension(ExtensionName)]
    public static class CURLConstants
    {
        /// <summary>
        /// Name of the cURL extension as it apears in PHP.
        /// </summary>
        internal const string ExtensionName = "curl";

        internal const string CurlResourceName = "curl";

        internal const string CurlMultiResourceName = "curl_multi";

        internal static Version FakeCurlVersion => new Version(7, 10, 1);

        #region Constants

        public const int CURLOPT_AUTOREFERER = 58;
        public const int CURLOPT_BINARYTRANSFER = 19914;
        public const int CURLOPT_BUFFERSIZE = 98;
        public const int CURLOPT_CAINFO = 10065;
        public const int CURLOPT_CAPATH = 10097;
        public const int CURLOPT_CONNECTTIMEOUT = 78;
        public const int CURLOPT_COOKIE = 10022;
        public const int CURLOPT_COOKIEFILE = 10031;
        public const int CURLOPT_COOKIEJAR = 10082;
        public const int CURLOPT_COOKIESESSION = 96;
        public const int CURLOPT_CRLF = 27;
        public const int CURLOPT_CUSTOMREQUEST = 10036;
        public const int CURLOPT_DNS_CACHE_TIMEOUT = 92;
        public const int CURLOPT_DNS_USE_GLOBAL_CACHE = 91;
        public const int CURLOPT_EGDSOCKET = 10077;
        public const int CURLOPT_ENCODING = 10102;
        public const int CURLOPT_FAILONERROR = 45;
        public const int CURLOPT_FILE = 10001;
        public const int CURLOPT_FILETIME = 69;
        public const int CURLOPT_FOLLOWLOCATION = 52;
        public const int CURLOPT_FORBID_REUSE = 75;
        public const int CURLOPT_FRESH_CONNECT = 74;
        public const int CURLOPT_FTPAPPEND = 50;
        public const int CURLOPT_FTPLISTONLY = 48;
        public const int CURLOPT_FTPPORT = 10017;
        public const int CURLOPT_FTP_USE_EPRT = 106;
        public const int CURLOPT_FTP_USE_EPSV = 85;
        public const int CURLOPT_HEADER = 42;
        public const int CURLOPT_HEADERFUNCTION = 20079;
        public const int CURLOPT_HTTP200ALIASES = 10104;
        public const int CURLOPT_HTTPGET = 80;
        public const int CURLOPT_HTTPHEADER = 10023;
        public const int CURLOPT_HTTPPROXYTUNNEL = 61;
        public const int CURLOPT_HTTP_VERSION = 84;
        public const int CURLOPT_INFILE = 10009;
        public const int CURLOPT_INFILESIZE = 14;
        public const int CURLOPT_INTERFACE = 10062;
        public const int CURLOPT_KRB4LEVEL = 10063;
        public const int CURLOPT_LOW_SPEED_LIMIT = 19;
        public const int CURLOPT_LOW_SPEED_TIME = 20;
        public const int CURLOPT_MAXCONNECTS = 71;
        public const int CURLOPT_MAXREDIRS = 68;
        public const int CURLOPT_NETRC = 51;
        public const int CURLOPT_NOBODY = 44;
        public const int CURLOPT_NOPROGRESS = 43;
        public const int CURLOPT_NOSIGNAL = 99;
        public const int CURLOPT_PORT = 3;
        public const int CURLOPT_POST = 47;
        public const int CURLOPT_POSTFIELDS = 10015;
        public const int CURLOPT_POSTQUOTE = 10039;
        public const int CURLOPT_PREQUOTE = 10093;
        public const int CURLOPT_PRIVATE = 10103;
        public const int CURLOPT_PROGRESSFUNCTION = 20056;
        public const int CURLOPT_PROXY = 10004;
        public const int CURLOPT_PROXYPORT = 59;
        public const int CURLOPT_PROXYTYPE = 101;
        public const int CURLOPT_PROXYUSERPWD = 10006;
        public const int CURLOPT_PUT = 54;
        public const int CURLOPT_QUOTE = 10028;
        public const int CURLOPT_RANDOM_FILE = 10076;
        public const int CURLOPT_RANGE = 10007;
        public const int CURLOPT_READDATA = 10009;
        public const int CURLOPT_READFUNCTION = 20012;
        public const int CURLOPT_REFERER = 10016;
        public const int CURLOPT_RESUME_FROM = 21;
        public const int CURLOPT_RETURNTRANSFER = 19913;
        public const int CURLOPT_SHARE = 10100;
        public const int CURLOPT_SSLCERT = 10025;
        public const int CURLOPT_SSLCERTPASSWD = 10026;
        public const int CURLOPT_SSLCERTTYPE = 10086;
        public const int CURLOPT_SSLENGINE = 10089;
        public const int CURLOPT_SSLENGINE_DEFAULT = 90;
        public const int CURLOPT_SSLKEY = 10087;
        public const int CURLOPT_SSLKEYPASSWD = 10026;
        public const int CURLOPT_SSLKEYTYPE = 10088;
        public const int CURLOPT_SSLVERSION = 32;
        public const int CURLOPT_SSL_CIPHER_LIST = 10083;
        public const int CURLOPT_SSL_VERIFYHOST = 81;
        public const int CURLOPT_SSL_VERIFYPEER = 64;
        public const int CURLOPT_STDERR = 10037;
        public const int CURLOPT_TELNETOPTIONS = 10070;
        public const int CURLOPT_TIMECONDITION = 33;
        public const int CURLOPT_TIMEOUT = 13;
        public const int CURLOPT_TIMEVALUE = 34;
        public const int CURLOPT_TRANSFERTEXT = 53;
        public const int CURLOPT_UNRESTRICTED_AUTH = 105;
        public const int CURLOPT_UPLOAD = 46;
        public const int CURLOPT_URL = 10002;
        public const int CURLOPT_USERAGENT = 10018;
        public const int CURLOPT_USERPWD = 10005;
        public const int CURLOPT_VERBOSE = 41;
        public const int CURLOPT_WRITEFUNCTION = 20011;
        public const int CURLOPT_WRITEHEADER = 10029;
        public const int CURLE_ABORTED_BY_CALLBACK = (int)CurlErrors.CURLE_ABORTED_BY_CALLBACK;
        public const int CURLE_BAD_CALLING_ORDER = (int)CurlErrors.CURLE_BAD_CALLING_ORDER;
        public const int CURLE_BAD_CONTENT_ENCODING = (int)CurlErrors.CURLE_BAD_CONTENT_ENCODING;
        public const int CURLE_BAD_DOWNLOAD_RESUME = (int)CurlErrors.CURLE_BAD_DOWNLOAD_RESUME;
        public const int CURLE_BAD_FUNCTION_ARGUMENT = (int)CurlErrors.CURLE_BAD_FUNCTION_ARGUMENT;
        public const int CURLE_BAD_PASSWORD_ENTERED = (int)CurlErrors.CURLE_BAD_PASSWORD_ENTERED;
        public const int CURLE_COULDNT_CONNECT = (int)CurlErrors.CURLE_COULDNT_CONNECT;
        public const int CURLE_COULDNT_RESOLVE_HOST = (int)CurlErrors.CURLE_COULDNT_RESOLVE_HOST;
        public const int CURLE_COULDNT_RESOLVE_PROXY = (int)CurlErrors.CURLE_COULDNT_RESOLVE_PROXY;
        public const int CURLE_FAILED_INIT = (int)CurlErrors.CURLE_FAILED_INIT;
        public const int CURLE_FILE_COULDNT_READ_FILE = (int)CurlErrors.CURLE_FILE_COULDNT_READ_FILE;
        public const int CURLE_FTP_ACCESS_DENIED = (int)CurlErrors.CURLE_FTP_ACCESS_DENIED;
        public const int CURLE_FTP_BAD_DOWNLOAD_RESUME = (int)CurlErrors.CURLE_FTP_BAD_DOWNLOAD_RESUME;
        public const int CURLE_FTP_CANT_GET_HOST = (int)CurlErrors.CURLE_FTP_CANT_GET_HOST;
        public const int CURLE_FTP_CANT_RECONNECT = (int)CurlErrors.CURLE_FTP_CANT_RECONNECT;
        public const int CURLE_FTP_COULDNT_GET_SIZE = (int)CurlErrors.CURLE_FTP_COULDNT_GET_SIZE;
        public const int CURLE_FTP_COULDNT_RETR_FILE = (int)CurlErrors.CURLE_FTP_COULDNT_RETR_FILE;
        public const int CURLE_FTP_COULDNT_SET_ASCII = (int)CurlErrors.CURLE_FTP_COULDNT_SET_ASCII;
        public const int CURLE_FTP_COULDNT_SET_BINARY = (int)CurlErrors.CURLE_FTP_COULDNT_SET_BINARY;
        public const int CURLE_FTP_COULDNT_STOR_FILE = (int)CurlErrors.CURLE_FTP_COULDNT_STOR_FILE;
        public const int CURLE_FTP_COULDNT_USE_REST = (int)CurlErrors.CURLE_FTP_COULDNT_USE_REST;
        public const int CURLE_FTP_PARTIAL_FILE = (int)CurlErrors.CURLE_FTP_PARTIAL_FILE;
        public const int CURLE_FTP_PORT_FAILED = (int)CurlErrors.CURLE_FTP_PORT_FAILED;
        public const int CURLE_FTP_QUOTE_ERROR = (int)CurlErrors.CURLE_FTP_QUOTE_ERROR;
        public const int CURLE_FTP_USER_PASSWORD_INCORRECT = (int)CurlErrors.CURLE_FTP_USER_PASSWORD_INCORRECT;
        public const int CURLE_FTP_WEIRD_227_FORMAT = (int)CurlErrors.CURLE_FTP_WEIRD_227_FORMAT;
        public const int CURLE_FTP_WEIRD_PASS_REPLY = (int)CurlErrors.CURLE_FTP_WEIRD_PASS_REPLY;
        public const int CURLE_FTP_WEIRD_PASV_REPLY = (int)CurlErrors.CURLE_FTP_WEIRD_PASV_REPLY;
        public const int CURLE_FTP_WEIRD_SERVER_REPLY = (int)CurlErrors.CURLE_FTP_WEIRD_SERVER_REPLY;
        public const int CURLE_FTP_WEIRD_USER_REPLY = (int)CurlErrors.CURLE_FTP_WEIRD_USER_REPLY;
        public const int CURLE_FTP_WRITE_ERROR = (int)CurlErrors.CURLE_FTP_WRITE_ERROR;
        public const int CURLE_FUNCTION_NOT_FOUND = (int)CurlErrors.CURLE_FUNCTION_NOT_FOUND;
        public const int CURLE_GOT_NOTHING = (int)CurlErrors.CURLE_GOT_NOTHING;
        public const int CURLE_HTTP_NOT_FOUND = (int)CurlErrors.CURLE_HTTP_NOT_FOUND;
        public const int CURLE_HTTP_PORT_FAILED = (int)CurlErrors.CURLE_HTTP_PORT_FAILED;
        public const int CURLE_HTTP_POST_ERROR = (int)CurlErrors.CURLE_HTTP_POST_ERROR;
        public const int CURLE_HTTP_RANGE_ERROR = (int)CurlErrors.CURLE_HTTP_RANGE_ERROR;
        public const int CURLE_HTTP_RETURNED_ERROR = (int)CurlErrors.CURLE_HTTP_RETURNED_ERROR;
        public const int CURLE_LDAP_CANNOT_BIND = (int)CurlErrors.CURLE_LDAP_CANNOT_BIND;
        public const int CURLE_LDAP_SEARCH_FAILED = (int)CurlErrors.CURLE_LDAP_SEARCH_FAILED;
        public const int CURLE_LIBRARY_NOT_FOUND = (int)CurlErrors.CURLE_LIBRARY_NOT_FOUND;
        public const int CURLE_MALFORMAT_USER = (int)CurlErrors.CURLE_MALFORMAT_USER;
        public const int CURLE_OBSOLETE = (int)CurlErrors.CURLE_OBSOLETE;
        public const int CURLE_OK = (int)CurlErrors.CURLE_OK;
        public const int CURLE_OPERATION_TIMEDOUT = (int)CurlErrors.CURLE_OPERATION_TIMEDOUT;
        public const int CURLE_OPERATION_TIMEOUTED = (int)CurlErrors.CURLE_OPERATION_TIMEOUTED;
        public const int CURLE_OUT_OF_MEMORY = (int)CurlErrors.CURLE_OUT_OF_MEMORY;
        public const int CURLE_PARTIAL_FILE = (int)CurlErrors.CURLE_PARTIAL_FILE;
        public const int CURLE_READ_ERROR = (int)CurlErrors.CURLE_READ_ERROR;
        public const int CURLE_RECV_ERROR = (int)CurlErrors.CURLE_RECV_ERROR;
        public const int CURLE_SEND_ERROR = (int)CurlErrors.CURLE_SEND_ERROR;
        public const int CURLE_SHARE_IN_USE = (int)CurlErrors.CURLE_SHARE_IN_USE;
        public const int CURLE_SSL_CACERT = (int)CurlErrors.CURLE_SSL_CACERT;
        public const int CURLE_SSL_CERTPROBLEM = (int)CurlErrors.CURLE_SSL_CERTPROBLEM;
        public const int CURLE_SSL_CIPHER = (int)CurlErrors.CURLE_SSL_CIPHER;
        public const int CURLE_SSL_CONNECT_ERROR = (int)CurlErrors.CURLE_SSL_CONNECT_ERROR;
        public const int CURLE_SSL_ENGINE_NOTFOUND = (int)CurlErrors.CURLE_SSL_ENGINE_NOTFOUND;
        public const int CURLE_SSL_ENGINE_SETFAILED = (int)CurlErrors.CURLE_SSL_ENGINE_SETFAILED;
        public const int CURLE_SSL_PEER_CERTIFICATE = (int)CurlErrors.CURLE_SSL_PEER_CERTIFICATE;
        public const int CURLE_SSL_PINNEDPUBKEYNOTMATCH = (int)CurlErrors.CURLE_SSL_PINNEDPUBKEYNOTMATCH;
        public const int CURLE_TELNET_OPTION_SYNTAX = (int)CurlErrors.CURLE_TELNET_OPTION_SYNTAX;
        public const int CURLE_TOO_MANY_REDIRECTS = (int)CurlErrors.CURLE_TOO_MANY_REDIRECTS;
        public const int CURLE_UNKNOWN_TELNET_OPTION = (int)CurlErrors.CURLE_UNKNOWN_TELNET_OPTION;
        public const int CURLE_UNSUPPORTED_PROTOCOL = (int)CurlErrors.CURLE_UNSUPPORTED_PROTOCOL;
        public const int CURLE_URL_MALFORMAT = (int)CurlErrors.CURLE_URL_MALFORMAT;
        public const int CURLE_URL_MALFORMAT_USER = (int)CurlErrors.CURLE_URL_MALFORMAT_USER;
        public const int CURLE_WRITE_ERROR = (int)CurlErrors.CURLE_WRITE_ERROR;
        public const int CURLE_FILESIZE_EXCEEDED = (int)CurlErrors.CURLE_FILESIZE_EXCEEDED;
        public const int CURLE_LDAP_INVALID_URL = (int)CurlErrors.CURLE_LDAP_INVALID_URL;
        public const int CURLE_FTP_SSL_FAILED = (int)CurlErrors.CURLE_FTP_SSL_FAILED;
        public const int CURLE_SSL_CACERT_BADFILE = (int)CurlErrors.CURLE_SSL_CACERT_BADFILE;
        public const int CURLE_SSH = (int)CurlErrors.CURLE_SSH;
        public const int CURLINFO_CONNECT_TIME = 3145733;
        /// <summary>
        /// Content length of download, read from Content-Length: field.
        /// </summary>
        public const int CURLINFO_CONTENT_LENGTH_DOWNLOAD = 3145743;
        public const int CURLINFO_CONTENT_LENGTH_UPLOAD = 3145744;
        public const int CURLINFO_CONTENT_TYPE = 1048594;
        public const int CURLINFO_EFFECTIVE_URL = 1048577;
        public const int CURLINFO_FILETIME = 2097166;
        public const int CURLINFO_HEADER_OUT = 2;
        public const int CURLINFO_HEADER_SIZE = 2097163;
        public const int CURLINFO_HTTP_CODE = 2097154;
        public const int CURLINFO_LASTONE = 49;
        public const int CURLINFO_NAMELOOKUP_TIME = 3145732;
        public const int CURLINFO_PRETRANSFER_TIME = 3145734;
        public const int CURLINFO_PRIVATE = 1048597;
        public const int CURLINFO_REDIRECT_COUNT = 2097172;
        public const int CURLINFO_REDIRECT_TIME = 3145747;
        public const int CURLINFO_REQUEST_SIZE = 2097164;
        public const int CURLINFO_SIZE_DOWNLOAD = 3145736;
        public const int CURLINFO_SIZE_UPLOAD = 3145735;
        public const int CURLINFO_SPEED_DOWNLOAD = 3145737;
        public const int CURLINFO_SPEED_UPLOAD = 3145738;
        public const int CURLINFO_SSL_VERIFYRESULT = 2097165;
        public const int CURLINFO_STARTTRANSFER_TIME = 3145745;
        /// <summary>Total transaction time in seconds for last transfer.</summary>
        public const int CURLINFO_TOTAL_TIME = 3145731;
        public const int CURLMSG_DONE = 1;
        public const int CURLVERSION_NOW = 4;
        public const int CURLM_BAD_EASY_HANDLE = (int)CurlMultiErrors.CURLM_BAD_EASY_HANDLE;
        public const int CURLM_BAD_HANDLE = (int)CurlMultiErrors.CURLM_BAD_HANDLE;
        public const int CURLM_CALL_MULTI_PERFORM = (int)CurlMultiErrors.CURLM_CALL_MULTI_PERFORM;
        public const int CURLM_INTERNAL_ERROR = (int)CurlMultiErrors.CURLM_INTERNAL_ERROR;
        public const int CURLM_OK = (int)CurlMultiErrors.CURLM_OK;
        public const int CURLM_OUT_OF_MEMORY = (int)CurlMultiErrors.CURLM_OUT_OF_MEMORY;
        public const int CURLM_ADDED_ALREADY = (int)CurlMultiErrors.CURLM_ADDED_ALREADY;
        public const int CURLPROXY_HTTP = 0;
        public const int CURLPROXY_SOCKS4 = 4;
        public const int CURLPROXY_SOCKS5 = 5;
        public const int CURLSHOPT_NONE = 0;
        public const int CURLSHOPT_SHARE = 1;
        public const int CURLSHOPT_UNSHARE = 2;
        public const int CURL_HTTP_VERSION_1_0 = 1;
        public const int CURL_HTTP_VERSION_1_1 = 2;
        public const int CURL_HTTP_VERSION_NONE = 0;
        public const int CURL_LOCK_DATA_COOKIE = 2;
        public const int CURL_LOCK_DATA_DNS = 3;
        public const int CURL_LOCK_DATA_SSL_SESSION = 4;
        public const int CURL_NETRC_IGNORED = 0;
        public const int CURL_NETRC_OPTIONAL = 1;
        public const int CURL_NETRC_REQUIRED = 2;
        public const int CURL_SSLVERSION_DEFAULT = 0;
        public const int CURL_SSLVERSION_SSLv2 = 2;
        public const int CURL_SSLVERSION_SSLv3 = 3;
        public const int CURL_SSLVERSION_TLSv1 = 1;
        public const int CURL_TIMECOND_IFMODSINCE = 1;
        public const int CURL_TIMECOND_IFUNMODSINCE = 2;
        public const int CURL_TIMECOND_LASTMOD = 3;
        public const int CURL_TIMECOND_NONE = 0;
        public const int CURL_VERSION_IPV6 = 1;
        public const int CURL_VERSION_KERBEROS4 = 2;
        public const int CURL_VERSION_LIBZ = 8;
        public const int CURL_VERSION_SSL = 4;
        public const int CURLOPT_HTTPAUTH = 107;
        public const long CURLAUTH_ANY = 4294967279;
        public const long CURLAUTH_ANYSAFE = 4294967278;
        public const int CURLAUTH_BASIC = 1;
        public const int CURLAUTH_DIGEST = 2;
        public const int CURLAUTH_GSSNEGOTIATE = 4;
        public const int CURLAUTH_NONE = 0;
        public const int CURLAUTH_NTLM = 8;
        public const int CURLINFO_HTTP_CONNECTCODE = 2097174;
        public const int CURLOPT_FTP_CREATE_MISSING_DIRS = 110;
        public const int CURLOPT_PROXYAUTH = 111;
        public const int CURLINFO_HTTPAUTH_AVAIL = 2097175;
        public const int CURLINFO_RESPONSE_CODE = 2097154;
        public const int CURLINFO_PROXYAUTH_AVAIL = 2097176;
        public const int CURLOPT_FTP_RESPONSE_TIMEOUT = 112;
        public const int CURLOPT_IPRESOLVE = 113;
        public const int CURLOPT_MAXFILESIZE = 114;
        public const int CURL_IPRESOLVE_V4 = 1;
        public const int CURL_IPRESOLVE_V6 = 2;
        public const int CURL_IPRESOLVE_WHATEVER = 0;
        public const int CURLFTPSSL_ALL = 3;
        public const int CURLFTPSSL_CONTROL = 2;
        public const int CURLFTPSSL_NONE = 0;
        public const int CURLFTPSSL_TRY = 1;
        public const int CURLOPT_FTP_SSL = 119;
        public const int CURLOPT_NETRC_FILE = 10118;
        public const int CURLFTPAUTH_DEFAULT = 0;
        public const int CURLFTPAUTH_SSL = 1;
        public const int CURLFTPAUTH_TLS = 2;
        public const int CURLOPT_FTPSSLAUTH = 129;
        public const int CURLOPT_FTP_ACCOUNT = 10134;
        public const int CURLOPT_TCP_NODELAY = 121;
        public const int CURLINFO_OS_ERRNO = 2097177;
        public const int CURLINFO_NUM_CONNECTS = 2097178;
        public const int CURLINFO_SSL_ENGINES = 4194331;
        public const int CURLINFO_COOKIELIST = 4194332;
        public const int CURLOPT_COOKIELIST = 10135;
        public const int CURLOPT_IGNORE_CONTENT_LENGTH = 136;
        public const int CURLOPT_FTP_SKIP_PASV_IP = 137;
        public const int CURLOPT_FTP_FILEMETHOD = 138;
        public const int CURLOPT_CONNECT_ONLY = 141;
        public const int CURLOPT_LOCALPORT = 139;
        public const int CURLOPT_LOCALPORTRANGE = 140;
        public const int CURLFTPMETHOD_MULTICWD = 1;
        public const int CURLFTPMETHOD_NOCWD = 2;
        public const int CURLFTPMETHOD_SINGLECWD = 3;
        public const int CURLINFO_FTP_ENTRY_PATH = 1048606;
        public const int CURLOPT_FTP_ALTERNATIVE_TO_USER = 10147;
        public const int CURLOPT_MAX_RECV_SPEED_LARGE = 30146;
        public const int CURLOPT_MAX_SEND_SPEED_LARGE = 30145;
        public const int CURLOPT_SSL_SESSIONID_CACHE = 150;
        public const int CURLMOPT_PIPELINING = 3;
        public const int CURLOPT_FTP_SSL_CCC = 154;
        public const int CURLOPT_SSH_AUTH_TYPES = 151;
        public const int CURLOPT_SSH_PRIVATE_KEYFILE = 10153;
        public const int CURLOPT_SSH_PUBLIC_KEYFILE = 10152;
        public const int CURLFTPSSL_CCC_ACTIVE = 2;
        public const int CURLFTPSSL_CCC_NONE = 0;
        public const int CURLFTPSSL_CCC_PASSIVE = 1;
        public const int CURLOPT_CONNECTTIMEOUT_MS = 156;
        public const int CURLOPT_HTTP_CONTENT_DECODING = 158;
        public const int CURLOPT_HTTP_TRANSFER_DECODING = 157;
        public const int CURLOPT_TIMEOUT_MS = 155;
        public const int CURLMOPT_MAXCONNECTS = 6;
        public const int CURLOPT_KRBLEVEL = 10063;
        public const int CURLOPT_NEW_DIRECTORY_PERMS = 160;
        public const int CURLOPT_NEW_FILE_PERMS = 159;
        public const int CURLOPT_APPEND = 50;
        public const int CURLOPT_DIRLISTONLY = 48;
        public const int CURLOPT_USE_SSL = 119;
        public const int CURLUSESSL_ALL = 3;
        public const int CURLUSESSL_CONTROL = 2;
        public const int CURLUSESSL_NONE = 0;
        public const int CURLUSESSL_TRY = 1;
        public const int CURLOPT_SSH_HOST_PUBLIC_KEY_MD5 = 10162;
        public const int CURLOPT_PROXY_TRANSFER_MODE = 166;
        public const int CURLPAUSE_ALL = 5;
        public const int CURLPAUSE_CONT = 0;
        public const int CURLPAUSE_RECV = 1;
        public const int CURLPAUSE_RECV_CONT = 0;
        public const int CURLPAUSE_SEND = 4;
        public const int CURLPAUSE_SEND_CONT = 0;
        public const int CURL_READFUNC_PAUSE = 268435457;
        public const int CURL_WRITEFUNC_PAUSE = 268435457;
        public const int CURLPROXY_SOCKS4A = 6;
        public const int CURLPROXY_SOCKS5_HOSTNAME = 7;
        public const int CURLINFO_REDIRECT_URL = 1048607;
        public const int CURLINFO_APPCONNECT_TIME = 3145761;
        public const int CURLINFO_PRIMARY_IP = 1048608;
        public const int CURLOPT_ADDRESS_SCOPE = 171;
        public const int CURLOPT_CRLFILE = 10169;
        public const int CURLOPT_ISSUERCERT = 10170;
        public const int CURLOPT_KEYPASSWD = 10026;
        public const int CURLSSH_AUTH_ANY = -1;
        public const int CURLSSH_AUTH_DEFAULT = -1;
        public const int CURLSSH_AUTH_HOST = 4;
        public const int CURLSSH_AUTH_KEYBOARD = 8;
        public const int CURLSSH_AUTH_NONE = 0;
        public const int CURLSSH_AUTH_PASSWORD = 2;
        public const int CURLSSH_AUTH_PUBLICKEY = 1;
        public const int CURLINFO_CERTINFO = 4194338;
        public const int CURLOPT_CERTINFO = 172;
        public const int CURLOPT_PASSWORD = 10174;
        public const int CURLOPT_POSTREDIR = 161;
        public const int CURLOPT_PROXYPASSWORD = 10176;
        public const int CURLOPT_PROXYUSERNAME = 10175;
        public const int CURLOPT_USERNAME = 10173;
        public const int CURL_REDIR_POST_301 = 1;
        public const int CURL_REDIR_POST_302 = 2;
        public const int CURL_REDIR_POST_ALL = 7;
        public const int CURLAUTH_DIGEST_IE = 16;
        public const int CURLINFO_CONDITION_UNMET = 2097187;
        public const int CURLOPT_NOPROXY = 10177;
        public const int CURLOPT_PROTOCOLS = 181;
        public const int CURLOPT_REDIR_PROTOCOLS = 182;
        public const int CURLOPT_SOCKS5_GSSAPI_NEC = 180;
        public const int CURLOPT_SOCKS5_GSSAPI_SERVICE = 10179;
        public const int CURLOPT_TFTP_BLKSIZE = 178;
        public const int CURLPROTO_ALL = -1;
        public const int CURLPROTO_DICT = 512;
        public const int CURLPROTO_FILE = 1024;
        public const int CURLPROTO_FTP = 4;
        public const int CURLPROTO_FTPS = 8;
        public const int CURLPROTO_HTTP = 1;
        public const int CURLPROTO_HTTPS = 2;
        public const int CURLPROTO_LDAP = 128;
        public const int CURLPROTO_LDAPS = 256;
        public const int CURLPROTO_SCP = 16;
        public const int CURLPROTO_SFTP = 32;
        public const int CURLPROTO_TELNET = 64;
        public const int CURLPROTO_TFTP = 2048;
        public const int CURLPROXY_HTTP_1_0 = 1;
        public const int CURLFTP_CREATE_DIR = 1;
        public const int CURLFTP_CREATE_DIR_NONE = 0;
        public const int CURLFTP_CREATE_DIR_RETRY = 2;
        public const int CURLOPT_SSH_KNOWNHOSTS = 10183;
        public const int CURLINFO_RTSP_CLIENT_CSEQ = 2097189;
        public const int CURLINFO_RTSP_CSEQ_RECV = 2097191;
        public const int CURLINFO_RTSP_SERVER_CSEQ = 2097190;
        public const int CURLINFO_RTSP_SESSION_ID = 1048612;
        public const int CURLOPT_FTP_USE_PRET = 188;
        public const int CURLOPT_MAIL_FROM = 10186;
        public const int CURLOPT_MAIL_RCPT = 10187;
        public const int CURLOPT_RTSP_CLIENT_CSEQ = 193;
        public const int CURLOPT_RTSP_REQUEST = 189;
        public const int CURLOPT_RTSP_SERVER_CSEQ = 194;
        public const int CURLOPT_RTSP_SESSION_ID = 10190;
        public const int CURLOPT_RTSP_STREAM_URI = 10191;
        public const int CURLOPT_RTSP_TRANSPORT = 10192;
        public const int CURLPROTO_IMAP = 4096;
        public const int CURLPROTO_IMAPS = 8192;
        public const int CURLPROTO_POP3 = 16384;
        public const int CURLPROTO_POP3S = 32768;
        public const int CURLPROTO_RTSP = 262144;
        public const int CURLPROTO_SMTP = 65536;
        public const int CURLPROTO_SMTPS = 131072;
        public const int CURL_RTSPREQ_ANNOUNCE = 3;
        public const int CURL_RTSPREQ_DESCRIBE = 2;
        public const int CURL_RTSPREQ_GET_PARAMETER = 8;
        public const int CURL_RTSPREQ_OPTIONS = 1;
        public const int CURL_RTSPREQ_PAUSE = 6;
        public const int CURL_RTSPREQ_PLAY = 5;
        public const int CURL_RTSPREQ_RECEIVE = 11;
        public const int CURL_RTSPREQ_RECORD = 10;
        public const int CURL_RTSPREQ_SET_PARAMETER = 9;
        public const int CURL_RTSPREQ_SETUP = 4;
        public const int CURL_RTSPREQ_TEARDOWN = 7;
        public const int CURLINFO_LOCAL_IP = 1048617;
        public const int CURLINFO_LOCAL_PORT = 2097194;
        public const int CURLINFO_PRIMARY_PORT = 2097192;
        public const int CURLOPT_FNMATCH_FUNCTION = 20200;
        public const int CURLOPT_WILDCARDMATCH = 197;
        public const int CURLPROTO_RTMP = 524288;
        public const int CURLPROTO_RTMPE = 2097152;
        public const int CURLPROTO_RTMPS = 8388608;
        public const int CURLPROTO_RTMPT = 1048576;
        public const int CURLPROTO_RTMPTE = 4194304;
        public const int CURLPROTO_RTMPTS = 16777216;
        public const int CURL_FNMATCHFUNC_FAIL = 2;
        public const int CURL_FNMATCHFUNC_MATCH = 0;
        public const int CURL_FNMATCHFUNC_NOMATCH = 1;
        public const int CURLPROTO_GOPHER = 33554432;
        public const long CURLAUTH_ONLY = 2147483648;
        public const int CURLOPT_RESOLVE = 10203;
        public const int CURLOPT_TLSAUTH_PASSWORD = 10205;
        public const int CURLOPT_TLSAUTH_TYPE = 10206;
        public const int CURLOPT_TLSAUTH_USERNAME = 10204;
        public const int CURL_TLSAUTH_SRP = 1;
        public const int CURLOPT_ACCEPT_ENCODING = 10102;
        public const int CURLOPT_TRANSFER_ENCODING = 207;
        public const int CURLAUTH_NTLM_WB = 32;
        public const int CURLGSSAPI_DELEGATION_FLAG = 2;
        public const int CURLGSSAPI_DELEGATION_POLICY_FLAG = 1;
        public const int CURLOPT_GSSAPI_DELEGATION = 210;
        public const int CURLOPT_ACCEPTTIMEOUT_MS = 212;
        public const int CURLOPT_DNS_SERVERS = 10211;
        public const int CURLOPT_MAIL_AUTH = 10217;
        public const int CURLOPT_SSL_OPTIONS = 216;
        public const int CURLOPT_TCP_KEEPALIVE = 213;
        public const int CURLOPT_TCP_KEEPIDLE = 214;
        public const int CURLOPT_TCP_KEEPINTVL = 215;
        public const int CURLSSLOPT_ALLOW_BEAST = 1;
        public const int CURL_REDIR_POST_303 = 4;
        public const int CURLSSH_AUTH_AGENT = 16;
        public const int CURLMOPT_CHUNK_LENGTH_PENALTY_SIZE = 30010;
        public const int CURLMOPT_CONTENT_LENGTH_PENALTY_SIZE = 30009;
        public const int CURLMOPT_MAX_HOST_CONNECTIONS = 7;
        public const int CURLMOPT_MAX_PIPELINE_LENGTH = 8;
        public const int CURLMOPT_MAX_TOTAL_CONNECTIONS = 13;
        public const int CURLOPT_SASL_IR = 218;
        public const int CURLOPT_DNS_INTERFACE = 10221;
        public const int CURLOPT_DNS_LOCAL_IP4 = 10222;
        public const int CURLOPT_DNS_LOCAL_IP6 = 10223;
        public const int CURLOPT_XOAUTH2_BEARER = 10220;
        public const int CURL_HTTP_VERSION_2_0 = 3;
        public const int CURL_VERSION_HTTP2 = 65536;
        public const int CURLOPT_LOGIN_OPTIONS = 10224;
        public const int CURL_SSLVERSION_TLSv1_0 = 4;
        public const int CURL_SSLVERSION_TLSv1_1 = 5;
        public const int CURL_SSLVERSION_TLSv1_2 = 6;
        public const int CURLOPT_EXPECT_100_TIMEOUT_MS = 227;
        public const int CURLOPT_SSL_ENABLE_ALPN = 226;
        public const int CURLOPT_SSL_ENABLE_NPN = 225;
        public const int CURLHEADER_SEPARATE = 1;
        public const int CURLHEADER_UNIFIED = 0;
        public const int CURLOPT_HEADEROPT = 229;
        public const int CURLOPT_PROXYHEADER = 10228;
        public const int CURLAUTH_NEGOTIATE = 4;
        public const int CURLOPT_PINNEDPUBLICKEY = 10230;
        public const int CURLOPT_UNIX_SOCKET_PATH = 10231;
        public const int CURLPROTO_SMB = 67108864;
        public const int CURLPROTO_SMBS = 134217728;
        public const int CURLOPT_SSL_VERIFYSTATUS = 232;
        public const int CURLOPT_PATH_AS_IS = 234;
        public const int CURLOPT_SSL_FALSESTART = 233;
        public const int CURL_HTTP_VERSION_2 = 3;
        public const int CURLOPT_PIPEWAIT = 237;
        public const int CURLOPT_PROXY_SERVICE_NAME = 10235;
        public const int CURLOPT_SERVICE_NAME = 10236;
        public const int CURLPIPE_NOTHING = 0;
        public const int CURLPIPE_HTTP1 = 1;
        public const int CURLPIPE_MULTIPLEX = 2;
        public const int CURLSSLOPT_NO_REVOKE = 2;
        public const int CURLOPT_DEFAULT_PROTOCOL = 10238;
        public const int CURLOPT_STREAM_WEIGHT = 239;
        public const int CURLMOPT_PUSHFUNCTION = 20014;
        public const int CURL_PUSH_OK = 0;
        public const int CURL_PUSH_DENY = 1;
        public const int CURL_HTTP_VERSION_2TLS = 4;
        public const int CURLOPT_TFTP_NO_OPTIONS = 242;
        public const int CURL_HTTP_VERSION_2_PRIOR_KNOWLEDGE = 5;
        public const int CURLOPT_CONNECT_TO = 10243;
        public const int CURLOPT_TCP_FASTOPEN = 244;
        public const int CURLOPT_SAFE_UPLOAD = -1;

        #endregion

        #region Helpers

        internal static bool TrySetOption(this CURLResource ch, int option, PhpValue value)
        {
            switch (option)
            {
                case CURLOPT_URL: return (ch.Url = value.AsString()) != null;
                case CURLOPT_DEFAULT_PROTOCOL: return (ch.DefaultSheme = value.AsString()) != null;
                case CURLOPT_HTTPGET: if (value.ToBoolean()) { ch.Method = WebRequestMethods.Http.Get; } break;
                case CURLOPT_POST: if (value.ToBoolean()) { ch.Method = WebRequestMethods.Http.Post; } break;
                case CURLOPT_PUT: if (value.ToBoolean()) { ch.Method = WebRequestMethods.Http.Put; } break;
                case CURLOPT_NOBODY: if (value.ToBoolean()) { ch.Method = WebRequestMethods.Http.Head; } break;
                case CURLOPT_CUSTOMREQUEST: return (ch.Method = value.AsString()) != null;
                case CURLOPT_POSTFIELDS: ch.PostFields = value.GetValue().DeepCopy(); break;
                case CURLOPT_FOLLOWLOCATION: ch.FollowLocation = value.ToBoolean(); break;
                case CURLOPT_MAXREDIRS: ch.MaxRedirects = (int)value.ToLong(); break;
                case CURLOPT_REFERER: return (ch.Referer = value.AsString()) != null;
                case CURLOPT_RETURNTRANSFER: ch.ReturnTransfer = value.ToBoolean(); break;
                case CURLOPT_HEADER: ch.OutputHeader = value.ToBoolean(); break;
                case CURLOPT_HTTPHEADER: ch.Headers = value.GetValue().DeepCopy().ToArray(); break;
                case CURLOPT_COOKIE: return (ch.CookieHeader = value.AsString()) != null;
                case CURLOPT_COOKIEFILE: ch.CookieFileSet = true; break;
                case CURLOPT_FILE: return (ch.OutputTransfer = value.Object as PhpStream) != null;
                case CURLOPT_INFILE: return (ch.PutStream = value.Object as PhpStream) != null;
                case CURLOPT_USERAGENT: return (ch.UserAgent = value.AsString()) != null;
                case CURLOPT_BINARYTRANSFER: return true;   // no effect
                case CURLOPT_PRIVATE: ch.Private = value.GetValue().DeepCopy(); return true;

                default:
                    PhpException.ArgumentValueNotSupported(nameof(option), option);
                    return false;
            }

            return true;
        }

        internal static bool TryGetOption(this CURLResource ch, int option, out PhpValue value)
        {
            switch (option)
            {
                default:
                    value = PhpValue.Null;
                    return false;
            }
        }

        internal static string GetErrorString(this CurlMultiErrors err)
        {
            return Resources.ResourceManager.GetString(err.ToString()) ?? Resources.UnknownError;
        }

        #endregion
    }

    #region CurlErrors

    /// <summary>
    /// <c>CURLE_</c> constants.
    /// </summary>
    public enum CurlErrors
    {
        CURLE_ABORTED_BY_CALLBACK = 42,
        CURLE_BAD_CALLING_ORDER = 44,
        CURLE_BAD_CONTENT_ENCODING = 61,
        CURLE_BAD_DOWNLOAD_RESUME = 36,
        CURLE_BAD_FUNCTION_ARGUMENT = 43,
        CURLE_BAD_PASSWORD_ENTERED = 46,
        CURLE_COULDNT_CONNECT = 7,
        CURLE_COULDNT_RESOLVE_HOST = 6,
        CURLE_COULDNT_RESOLVE_PROXY = 5,
        CURLE_FAILED_INIT = 2,
        CURLE_FILE_COULDNT_READ_FILE = 37,
        CURLE_FTP_ACCESS_DENIED = 9,
        CURLE_FTP_BAD_DOWNLOAD_RESUME = 36,
        CURLE_FTP_CANT_GET_HOST = 15,
        CURLE_FTP_CANT_RECONNECT = 16,
        CURLE_FTP_COULDNT_GET_SIZE = 32,
        CURLE_FTP_COULDNT_RETR_FILE = 19,
        CURLE_FTP_COULDNT_SET_ASCII = 29,
        CURLE_FTP_COULDNT_SET_BINARY = 17,
        CURLE_FTP_COULDNT_STOR_FILE = 25,
        CURLE_FTP_COULDNT_USE_REST = 31,
        CURLE_FTP_PARTIAL_FILE = 18,
        CURLE_FTP_PORT_FAILED = 30,
        CURLE_FTP_QUOTE_ERROR = 21,
        CURLE_FTP_USER_PASSWORD_INCORRECT = 10,
        CURLE_FTP_WEIRD_227_FORMAT = 14,
        CURLE_FTP_WEIRD_PASS_REPLY = 11,
        CURLE_FTP_WEIRD_PASV_REPLY = 13,
        CURLE_FTP_WEIRD_SERVER_REPLY = 8,
        CURLE_FTP_WEIRD_USER_REPLY = 12,
        CURLE_FTP_WRITE_ERROR = 20,
        CURLE_FUNCTION_NOT_FOUND = 41,
        CURLE_GOT_NOTHING = 52,
        CURLE_HTTP_NOT_FOUND = 22,
        CURLE_HTTP_PORT_FAILED = 45,
        CURLE_HTTP_POST_ERROR = 34,
        CURLE_HTTP_RANGE_ERROR = 33,
        CURLE_HTTP_RETURNED_ERROR = 22,
        CURLE_LDAP_CANNOT_BIND = 38,
        CURLE_LDAP_SEARCH_FAILED = 39,
        CURLE_LIBRARY_NOT_FOUND = 40,
        CURLE_MALFORMAT_USER = 24,
        CURLE_OBSOLETE = 50,
        CURLE_OK = 0,
        CURLE_OPERATION_TIMEDOUT = 28,
        CURLE_OPERATION_TIMEOUTED = 28,
        CURLE_OUT_OF_MEMORY = 27,
        CURLE_PARTIAL_FILE = 18,
        CURLE_READ_ERROR = 26,
        CURLE_RECV_ERROR = 56,
        CURLE_SEND_ERROR = 55,
        CURLE_SHARE_IN_USE = 57,
        CURLE_SSL_CACERT = 60,
        CURLE_SSL_CERTPROBLEM = 58,
        CURLE_SSL_CIPHER = 59,
        CURLE_SSL_CONNECT_ERROR = 35,
        CURLE_SSL_ENGINE_NOTFOUND = 53,
        CURLE_SSL_ENGINE_SETFAILED = 54,
        CURLE_SSL_PEER_CERTIFICATE = 51,
        CURLE_SSL_PINNEDPUBKEYNOTMATCH = 90,
        CURLE_TELNET_OPTION_SYNTAX = 49,
        CURLE_TOO_MANY_REDIRECTS = 47,
        CURLE_UNKNOWN_TELNET_OPTION = 48,
        CURLE_UNSUPPORTED_PROTOCOL = 1,
        CURLE_URL_MALFORMAT = 3,
        CURLE_URL_MALFORMAT_USER = 4,
        CURLE_WRITE_ERROR = 23,
        CURLE_FILESIZE_EXCEEDED = 63,
        CURLE_LDAP_INVALID_URL = 62,
        CURLE_FTP_SSL_FAILED = 64,
        CURLE_SSL_CACERT_BADFILE = 77,
        CURLE_SSH = 79,
    }

    #endregion

    #region CurlMultiErrors

    /// <summary>
    /// <c>CURLM_*</c> constants.
    /// </summary>
    /// <remarks>The names correspond to resources, see <see cref="Resources"/>.</remarks>
    public enum CurlMultiErrors
    {
        CURLM_OK = 0,
        CURLM_BAD_HANDLE = 1,
        CURLM_BAD_EASY_HANDLE = 2,
        CURLM_OUT_OF_MEMORY = 3,
        CURLM_INTERNAL_ERROR = 4,
        CURLM_ADDED_ALREADY = 7,
        CURLM_CALL_MULTI_PERFORM = -1,
    }

    #endregion
}
