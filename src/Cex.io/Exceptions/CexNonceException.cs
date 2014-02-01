namespace Nextmethod.Cex.Exceptions {
    using System.Net.Http;

    public class CexNonceException : CexApiException {

        public CexNonceException( HttpResponseMessage response, string message ) : base( response, message ) { }

    }
}
