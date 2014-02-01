namespace Nextmethod.Cex.Helpers {
    using System;

    public static class CexRounding {

        private const decimal CexRoundingFactor = 100000000M;

        public static decimal CexRound( this decimal This ) {
            if ( This == 0.0M ) return This;
            return ( Math.Ceiling( This * CexRoundingFactor ) ) / CexRoundingFactor;
        }


    }
}
