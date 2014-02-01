namespace Nextmethod.Cex.Entities {
    public class WorkerHashrate : Hashrate {

        public WorkerRejects Rejected { get; internal set; }

        public override string ToString() {
            return string.Format( "{0}, Rejected: {1}", base.ToString(), this.Rejected );
        }


        new internal static WorkerHashrate FromDynamic( dynamic data ) {
            var val = Hashrate.CreateFromDynamic( data, new WorkerHashrate() );
            val.Rejected = WorkerRejects.FromDynamic( data[ "rejected" ] );
            return val;
        }

    }
}
