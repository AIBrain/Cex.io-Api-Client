namespace Nextmethod.Cex.Entities {
    using System;
    using System.Linq;

    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable InconsistentNaming
    public class Balance {
        public SymbolBalance BF1 { get; internal set; }

        public SymbolBalance BTC { get; internal set; }

        public SymbolBalance DVC { get; internal set; }

        public SymbolBalance GHS { get; internal set; }

        public SymbolBalance IXC { get; internal set; }

        public SymbolBalance LTC { get; internal set; }

        public SymbolBalance NMC { get; internal set; }

        public Timestamp Timestamp { get; internal set; }

        public Balance() {
            this.BF1 = SymbolBalance.Zero;
            this.BTC = SymbolBalance.Zero;
            this.DVC = SymbolBalance.Zero;
            this.GHS = SymbolBalance.Zero;
            this.IXC = SymbolBalance.Zero;
            this.LTC = SymbolBalance.Zero;
            this.NMC = SymbolBalance.Zero;
        }

        internal static Balance FromDynamic( dynamic data ) {
            var balance = new Balance();
            var json = data as JsonObject;
            if ( json == null ) return balance;

            foreach ( var sym in Enum.GetValues( typeof( Symbol ) ).Cast<Symbol>() ) {
                if ( !json.ContainsKey( sym.Name() ) ) {
                    continue;
                }
                var symJson = json[ sym.Name() ] as JsonObject;
                if ( symJson != null ) {
                    balance[ sym ] = SymbolBalance.FromDynamic( symJson );
                }
            }

            balance.Timestamp = data[ "timestamp" ];

            return balance;
        }

        public SymbolBalance this[ Symbol s ] {

            #region Symbol Indexer

            get {
                switch ( s ) {
                    case Symbol.BF1:
                        return this.BF1;

                    case Symbol.BTC:
                        return this.BTC;

                    case Symbol.DVC:
                        return this.DVC;

                    case Symbol.GHS:
                        return this.GHS;

                    case Symbol.IXC:
                        return this.IXC;

                    case Symbol.LTC:
                        return this.LTC;

                    case Symbol.NMC:
                        return this.NMC;

                    default:
                        throw new IndexOutOfRangeException( string.Format( "{0} does not exist", s.Name() ) );
                }
            }

            internal set {
                switch ( s ) {
                    case Symbol.BF1:
                        this.BF1 = value;
                        break;

                    case Symbol.BTC:
                        this.BTC = value;
                        break;

                    case Symbol.DVC:
                        this.DVC = value;
                        break;

                    case Symbol.GHS:
                        this.GHS = value;
                        break;

                    case Symbol.IXC:
                        this.IXC = value;
                        break;

                    case Symbol.LTC:
                        this.LTC = value;
                        break;

                    case Symbol.NMC:
                        this.NMC = value;
                        break;

                    default:
                        throw new IndexOutOfRangeException( string.Format( "{0} does not exist", s.Name() ) );
                }
            }

            #endregion

        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore MemberCanBePrivate.Global
}