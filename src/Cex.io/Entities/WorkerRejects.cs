namespace Nextmethod.Cex.Entities {
    using System;

    public class WorkerRejects {
        public long Stale { get; internal set; }

        public long Duplicate { get; internal set; }

        public long LowDiff { get; internal set; }

        internal static WorkerRejects FromDynamic( dynamic data ) {
            return new WorkerRejects {
                Stale = Convert.ToInt64( data[ "stale" ] ),
                Duplicate = Convert.ToInt64( data[ "duplicate" ] ),
                LowDiff = Convert.ToInt64( data[ "lowdiff" ] )
            };
        }

        public override string ToString() {
            return string.Format( "Stale: {0}, Duplicate: {1}, LowDiff: {2}", this.Stale, this.Duplicate, this.LowDiff );
        }
    }
}