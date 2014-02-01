namespace Nextmethod.Cex.Exceptions {
    using System;
    using System.Net;
    using System.Net.Http;

    public class CexApiException : Exception {
        public HttpMethod RequestMethod { get; private set; }

        public Uri RequestUri { get; private set; }

        public HttpStatusCode ResponseStatusCode { get; private set; }

        public string ResponseReasonPhrase { get; private set; }

        public CexApiException( HttpResponseMessage response, string message )
            : base( message ) {
            var request = response.RequestMessage;
            this.RequestMethod = request.Method;
            this.RequestUri = request.RequestUri;

            this.ResponseStatusCode = response.StatusCode;
            this.ResponseReasonPhrase = response.ReasonPhrase;
        }

        public override string ToString() {
            return string.Format( "{0}, RequestMethod: {1}, RequestUri: {2}, ResponseStatusCode: {3}, ResponseReasonPhrase: {4}", base.ToString(), this.RequestMethod, this.RequestUri, this.ResponseStatusCode, this.ResponseReasonPhrase );
        }
    }
}
