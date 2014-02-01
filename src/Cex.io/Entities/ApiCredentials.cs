namespace Nextmethod.Cex.Entities {
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using Annotations;

    public sealed class ApiCredentials {
        private readonly HMAC _hmac;

        public string Username { get; private set; }

        public string ApiKey { get; private set; }

        public ApiCredentials( [NotNull] string username, [NotNull] string apiKey, [NotNull] string apiSecret ) {
            if ( username == null )
                throw new ArgumentNullException( "username" );
            if ( apiKey == null )
                throw new ArgumentNullException( "apiKey" );
            if ( apiSecret == null )
                throw new ArgumentNullException( "apiSecret" );
            this.Username = username;
            this.ApiKey = apiKey;
            this._hmac = new HMACSHA256( EncodingHelpers.EncodeString( apiSecret ) );
        }

        public string NewSignature( out long nonce ) {
            var n = Nonce.Next;
            var bytes = EncodingHelpers.EncodeString( string.Format( "{0}{1}{2}", n, this.Username, this.ApiKey ) );
            var hash = this._hmac.ComputeHash( bytes );

            nonce = n;
            // Hexencode hash
            return string.Concat( hash.Select( b => b.ToString( "X2" ) ) );
        }
    }
}
