namespace Nextmethod.Cex.Helpers
{
    internal static class Constants
    {

        #region Api Related
        internal const string GhashBaseApiUri = CexBaseApiUri + "/ghash.io";
        internal const string ApiParamAmount = "amount";
        internal const string ApiParamKey = "key";
        internal const string ApiParamNonce = "nonce";
        internal const string ApiParamPrice = "price";
        internal const string ApiParamSignature = "signature";
        internal const string ApiParamType = "type";
        internal const string ErrorProperty = "error";
        internal const string InvalidApiKey = "Invalid API key";
        internal const string NonceMustBeIncremented = "Nonce must be incremented";
        internal const string PermissionDenied = "Permission denied";
        internal const int DefaultConnectionLimit = 2;
        internal const int DesiredConnectionLimit = 100;
        internal const string CexBaseApiUri = "https://cex.io/api";
        #endregion


        #region Exception Related
        #endregion


        #region HttpClient Related
        #endregion
    }
}
