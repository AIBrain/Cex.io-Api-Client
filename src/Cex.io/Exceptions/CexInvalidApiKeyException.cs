namespace Nextmethod.Cex.Exceptions {
    using System.Net.Http;

    public class CexInvalidApiKeyException : CexApiException {

        public CexInvalidApiKeyException( HttpResponseMessage response, string message ) : base( response, message ) { }

    }
}
