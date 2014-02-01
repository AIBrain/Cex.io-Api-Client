namespace Nextmethod.Cex.Entities {
    using System;

    public class SymbolBalance {
        private const decimal DecZero = 0.0m;

        public static readonly SymbolBalance Zero = new SymbolBalance();

        public decimal Available { get; private set; }

        public decimal Bonus { get; private set; }

        public decimal Orders { get; private set; }

        public SymbolBalance( decimal available = DecZero, decimal bonus = DecZero, decimal orders = DecZero ) {
            this.Available = available != DecZero ? available : DecZero;
            this.Bonus = bonus != DecZero ? bonus : DecZero;
            this.Orders = orders != DecZero ? orders : DecZero;
        }

        internal static SymbolBalance FromDynamic( JsonObject data ) {
            var available = data.ContainsKey( "available" ) ? Convert.ToDecimal( data[ "available" ] ) : 0m;
            var bonus = data.ContainsKey( "bonus" ) ? Convert.ToDecimal( data[ "bonus" ] ) : 0m;
            var orders = data.ContainsKey( "orders" ) ? Convert.ToDecimal( data[ "orders" ] ) : 0m;

            return new SymbolBalance( available, bonus, orders );
        }

        public override string ToString() {
            return string.Format( "Available: {0}, Bonus: {1}, Orders: {2}", this.Available, this.Bonus, this.Orders );
        }
    }
}