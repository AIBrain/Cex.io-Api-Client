namespace Nextmethod.Cex.Entities {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderBook {
        public IEnumerable<OrderBookOrder> Asks { get; internal set; }

        public IEnumerable<OrderBookOrder> Bids { get; internal set; }

        public Timestamp Timestamp { get; private set; }

        internal static OrderBook FromDynamic( dynamic data ) {
            return new OrderBook {
                Asks = ( ( IEnumerable<object> )data[ "asks" ] ).Select( ParseOrder ).ToArray(),
                Bids = ( ( IEnumerable<object> )data[ "bids" ] ).Select( ParseOrder ).ToArray(),
                Timestamp = data[ "timestamp" ]
            };
        }

        private static OrderBookOrder ParseOrder( dynamic orderData ) {
            var price = orderData[ 0 ];
            var quantity = orderData[ 1 ];
            return new OrderBookOrder(
                Convert.ToDecimal( price ),
                decimal.Parse( quantity )
                );
        }

        public override string ToString() {
            return string.Format( "Asks: {0}, Bids: {1}, Timestamp: {2}", this.Asks.Count(), this.Bids.Count(), this.Timestamp );
        }
    }

}
