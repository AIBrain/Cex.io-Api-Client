﻿namespace Nextmethod.Cex {
    using System;
    using System.Net.Http;
    using Helpers;

    public static class HttpClientFactory {

        public static int? ConnectionLimit { get; set; }

        public static Func<HttpClient> Get { get; set; }

        static HttpClientFactory() {
            Get = () => new HttpClient();
        }

    }

    public static class ApiUriFactory {

        public static Func<Uri> GetCex { get; set; }

        public static Func<Uri> GetGHash { get; set; }

        static ApiUriFactory() {
            GetCex = () => new Uri( Constants.CexBaseApiUri );
            GetGHash = () => new Uri( Constants.GhashBaseApiUri );
        }

    }
}
