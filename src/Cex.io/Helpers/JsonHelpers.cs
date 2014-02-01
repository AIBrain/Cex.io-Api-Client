namespace Nextmethod.Cex.Helpers {
    internal static class JsonHelpers {

        internal static bool ContainsProperty( dynamic json, string name ) {
            if ( json == null || string.IsNullOrEmpty( name ) ) return false;
            var jo = json as JsonObject;
            if ( jo != null ) {
                return jo.ContainsKey( name );
            }

            var ja = json as JsonArray;
            if ( ja != null ) {
                return false;
            }

            if ( ( json is bool ) || Equals( json, bool.FalseString ) || Equals( json, bool.TrueString ) ) return false;

            return json.GetType().GetProperty( name );
        }

    }
}
