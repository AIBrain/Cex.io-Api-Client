using System;
using System.Linq;
using System.Net.Http;

namespace Nextmethod.Cex
{
    using Exceptions;

    public class CexPermissionDeniedException : CexApiException
    {

        public CexPermissionDeniedException(HttpResponseMessage response, string message) : base(response, message) {}

    }
}
