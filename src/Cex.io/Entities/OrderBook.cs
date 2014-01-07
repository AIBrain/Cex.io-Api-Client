﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Nextmethod.Cex
{
    public class OrderBook
    {

        public IEnumerable<Order> Asks { get; internal set; }

        public IEnumerable<Order> Bids { get; internal set; }

        public Timestamp Timestamp { get; private set; }

        public override string ToString()
        {
            return string.Format("Asks: {0}, Bids: {1}, Timestamp: {2}", Asks.Count(), Bids.Count(), Timestamp);
        }

        public struct Order
        {

            private readonly decimal _amount;

            private readonly decimal _price;

            public Order(decimal price, decimal amount)
            {
                _price = price;
                _amount = amount;
            }

            public decimal Price
            {
                get { return _price; }
            }

            public decimal Amount
            {
                get { return _amount; }
            }

            public override string ToString()
            {
                return string.Format("Price: {0}, Amount: {1}", Price, Amount);
            }

        }

        internal static OrderBook FromDynamic(dynamic data)
        {
            return new OrderBook
            {
                Asks = ((IEnumerable<object>) data["asks"]).Select(ParseOrder).ToArray(),
                Bids = ((IEnumerable<object>) data["bids"]).Select(ParseOrder).ToArray(),
                Timestamp = data["timestamp"]
            };
        }

        private static Order ParseOrder(dynamic orderData)
        {
            var price = orderData[0];
            var quantity = orderData[1];
            return new Order(
                Convert.ToDecimal(price),
                decimal.Parse(quantity)
                );
        }

    }
}
