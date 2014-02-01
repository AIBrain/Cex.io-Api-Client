namespace Nextmethod.Cex.Entities {
    // ReSharper disable InconsistentNaming
    public enum Symbol {
        BF1,
        BTC,
        DVC,
        GHS,
        IXC,
        LTC,
        NMC
    }

    // ReSharper restore InconsistentNaming


    internal static class SymbolExtensions {

        public static string Name( this Symbol sym ) {
            return sym.ToString();
        }

    }

}
