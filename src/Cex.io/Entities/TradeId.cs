namespace Nextmethod.Cex.Entities {
    using System;
    using System.Globalization;

    public struct TradeId : IComparable, IComparable<TradeId>, IFormattable, IEquatable<TradeId> {

        private readonly uint _id;

        public TradeId( uint id ) {
            this._id = id;
        }

        public uint Id {
            get { return this._id; }
        }

        public override string ToString() {
            return this._id.ToString( CultureInfo.DefaultThreadCurrentCulture );
        }

        public string ToString( string format, IFormatProvider formatProvider ) {
            return this._id.ToString( format, formatProvider );
        }

        public bool Equals( TradeId other ) {
            return this._id == other._id;
        }

        public override bool Equals( object obj ) {
            if ( ReferenceEquals( null, obj ) ) { return false; }
            return obj is TradeId && this.Equals( ( TradeId )obj );
        }

        public override int GetHashCode() {
            return ( int )this._id;
        }

        public static bool operator ==( TradeId left, TradeId right ) {
            return left.Equals( right );
        }

        public static bool operator !=( TradeId left, TradeId right ) {
            return !left.Equals( right );
        }

        public int CompareTo( object obj ) {
            if ( obj == null ) return 1;
            if ( !( obj is TradeId ) ) throw new ArgumentException( "Object must be of type TradeId" );

            return this.CompareTo( ( TradeId )obj );
        }

        public int CompareTo( TradeId other ) {
            return other == null ? 1 : this._id.CompareTo( other._id );
        }

        public static implicit operator TradeId( int value ) {
            if ( value < 0 ) throw new ArgumentOutOfRangeException( "value", value, "Value must be >= 0" );
            return new TradeId( ( uint )value );
        }

        public static implicit operator int( TradeId value ) {
            if ( value == null ) throw new ArgumentNullException( "value" );
            return Convert.ToInt32( value.Id );
        }

        public static implicit operator TradeId( long value ) {
            if ( value < 0 ) throw new ArgumentOutOfRangeException( "value", value, "Value must be >= 0" );
            return new TradeId( Convert.ToUInt32( value ) );
        }

        public static implicit operator long( TradeId value ) {
            if ( value == null ) throw new ArgumentNullException( "value" );
            return Convert.ToInt64( value.Id );
        }

        public static implicit operator TradeId( string value ) {
            return new TradeId( uint.Parse( value ) );
        }
    }
}