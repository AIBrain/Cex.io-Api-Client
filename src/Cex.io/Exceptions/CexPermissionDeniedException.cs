namespace Nextmethod.Cex.Exceptions {
    using System.Net.Http;

    public class CexPermissionDeniedException : CexApiException {

        public CexPermissionDeniedException( HttpResponseMessage response, string message ) : base( response, message ) { }

    }
}
