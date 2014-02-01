namespace Nextmethod.Cex.Entities {
    using System;

    public class Hashrate {
        public decimal Last5Minutes { get; internal set; }

        public decimal Last15Minutes { get; internal set; }

        public decimal LastHour { get; internal set; }

        public decimal LastDay { get; internal set; }

        public decimal Previous5Minutes { get; internal set; }

        public decimal Previous15Minutes { get; internal set; }

        public decimal PreviousHour { get; internal set; }

        public decimal PreviousDay { get; internal set; }

        internal static Hashrate FromDynamic( dynamic data ) {
            return CreateFromDynamic( data, new Hashrate() );
        }

        internal static T CreateFromDynamic<T>( dynamic data, T val )
            where T : Hashrate {
            val.Last5Minutes = Convert.ToDecimal( data[ "last5m" ] );
            val.Last15Minutes = Convert.ToDecimal( data[ "last15m" ] );
            val.LastHour = Convert.ToDecimal( data[ "last1h" ] );
            val.LastDay = Convert.ToDecimal( data[ "last1d" ] );
            val.Previous5Minutes = Convert.ToDecimal( data[ "prev5m" ] );
            val.Previous15Minutes = Convert.ToDecimal( data[ "prev15m" ] );
            val.PreviousHour = Convert.ToDecimal( data[ "prev1h" ] );
            val.PreviousDay = Convert.ToDecimal( data[ "prev1d" ] );

            return val;
        }

        public override string ToString() {
            return string.Format(
                "Last5Minutes: {0}, Last15Minutes: {1}, LastHour: {2}, LastDay: {3}, Previous5Minutes: {4}, Previous15Minutes: {5}, PreviousHour: {6}, PreviousDay: {7}",
                this.Last5Minutes,
                this.Last15Minutes,
                this.LastHour,
                this.LastDay,
                this.Previous5Minutes,
                this.Previous15Minutes,
                this.PreviousHour,
                this.PreviousDay );
        }
    }
}
