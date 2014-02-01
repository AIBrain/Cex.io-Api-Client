namespace Nextmethod.Cex.Helpers {
    using System.Collections.Generic;

    internal static class KvPair {

        public static KeyValuePair<TKey, TValue> New<TKey, TValue>( TKey key, TValue val ) {
            return new KeyValuePair<TKey, TValue>( key, val );
        }

    }
}
