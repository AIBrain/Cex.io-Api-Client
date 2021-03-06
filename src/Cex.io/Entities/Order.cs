﻿namespace Nextmethod.Cex.Entities {
    public class Order {

        public decimal Amount { get; set; }

        public decimal Price { get; set; }

        public OrderType Type { get; set; }


        public override string ToString() {
            return string.Format( "Amount: {0}, Price: {1}, Type: {2}", this.Amount, this.Price, this.Type );
        }

    }
}
