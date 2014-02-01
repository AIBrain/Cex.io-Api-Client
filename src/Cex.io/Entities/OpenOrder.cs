﻿namespace Nextmethod.Cex.Entities {
    using System;

    public class OpenOrder : Order {


        public TradeId Id { get; internal set; }

        public decimal Pending { get; internal set; }
        public Timestamp Time { get; internal set; }


        public override string ToString() {
            return string.Format( "Id: {0}, Type: {1}, Amount: {2}, Price: {3}, Pending: {4}, Time: {5}", this.Id, this.Type, this.Amount, this.Price, this.Pending, this.Time );
        }

        internal static OpenOrder FromDynamic( dynamic data ) {
            return new OpenOrder {
                Amount = decimal.Parse( data[ "amount" ] ),
                Id = data[ "id" ],
                Pending = decimal.Parse( data[ "pending" ] ),
                Price = decimal.Parse( data[ "price" ] ),
                Time = data[ "time" ],
                Type = Convert.ToString( data[ "type" ] ) == "sell" ? OrderType.Sell : OrderType.Buy
            };
        }

    }
}
