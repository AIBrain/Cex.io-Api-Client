namespace Nextmethod.Cex.Entities {
    using System;

    public struct OrderBookOrder {

        private readonly decimal _amount;

        private readonly decimal _price;

        public OrderBookOrder( decimal price, decimal amount ) {
            this._price = price;
            this._amount = amount;
        }

        public decimal Price {
            get { return this._price; }
        }

        public decimal Amount {
            get { return this._amount; }
        }

        public override string ToString() {
            return String.Format( "Price: {0}, Amount: {1}", this.Price, this.Amount );
        }

    }
}