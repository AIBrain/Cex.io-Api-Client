namespace Nextmethod.Cex.Entities {
    using System;
    using System.Collections.Generic;
    using Annotations;

    public sealed class SymbolPair {
        public static readonly SymbolPair GHS_BTC = new SymbolPair( Symbol.GHS, Symbol.BTC );
        public static readonly SymbolPair GHS_NMC = new SymbolPair( Symbol.GHS, Symbol.NMC );
        public static readonly SymbolPair LTC_BTC = new SymbolPair( Symbol.LTC, Symbol.BTC );
        public static readonly SymbolPair NMC_BTC = new SymbolPair( Symbol.NMC, Symbol.BTC );
        public static readonly SymbolPair BF1_BTC = new SymbolPair( Symbol.BF1, Symbol.BTC );

        public Symbol From { get; private set; }

        public Symbol To { get; private set; }

        private SymbolPair( KeyValuePair<Symbol, Symbol> pair )
            : this( pair.Key, pair.Value ) { }

        private SymbolPair( Symbol @from, Symbol to ) {
            this.From = @from;
            this.To = to;
        }

        public override int GetHashCode() {
            unchecked { return ( ( int )this.From * 397 ) ^ ( int )this.To; }
        }

        public override bool Equals( [CanBeNull] object obj ) {
            if ( ReferenceEquals( null, obj ) ) { return false; }
            if ( ReferenceEquals( this, obj ) ) { return true; }
            return obj.GetType() == this.GetType() && this.Equals( ( SymbolPair )obj );
        }

        public bool Equals( [NotNull] SymbolPair other ) {
            if ( other == null )
                throw new ArgumentNullException( "other" );
            return this.From == other.From && this.To == other.To;
        }

        public static bool operator !=( SymbolPair left, SymbolPair right ) {
            return !Equals( left, right );
        }

        public static bool operator ==( SymbolPair left, SymbolPair right ) {
            return Equals( left, right );
        }
    }
}