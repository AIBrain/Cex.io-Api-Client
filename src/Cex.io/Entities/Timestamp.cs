namespace Nextmethod.Cex.Entities {
    using System;
    using System.Diagnostics;

    public struct Timestamp : IComparable, IComparable<Timestamp>, IFormattable, IEquatable<Timestamp> {

        [DebuggerBrowsable( DebuggerBrowsableState.Never )]
        public static readonly DateTime EpochStart = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );

        // ReSharper disable InconsistentNaming
        private readonly uint Value;
        // ReSharper restore InconsistentNaming

        public Timestamp( uint value ) {
            this.Value = value;
        }

        [DebuggerBrowsable( DebuggerBrowsableState.Never )]
        public static Timestamp Now {
            get { return DateTime.UtcNow; }
        }

        public DateTime ToUtcDateTime() {
            return this;
        }

        public DateTime ToLocalDateTime() {
            return this.ToUtcDateTime().ToLocalTime();
        }

        public override string ToString() {
            return this.ToUtcDateTime().ToString( "u" );
        }

        public string ToString( string format, IFormatProvider formatProvider ) {
            return this.ToUtcDateTime().ToString( format, formatProvider );
        }


        #region Equality Crap

        public override bool Equals( object obj ) {
            if ( ReferenceEquals( null, obj ) ) { return false; }
            return obj is Timestamp && this.Equals( ( Timestamp )obj );
        }

        public bool Equals( Timestamp other ) {
            return this.Value == other.Value;
        }

        public override int GetHashCode() {
            return this.Value.GetHashCode();
        }

        public static bool operator ==( Timestamp left, Timestamp right ) {
            return left.Equals( right );
        }

        public static bool operator !=( Timestamp left, Timestamp right ) {
            return !left.Equals( right );
        }

        #endregion


        #region Comparable Crap

        public int CompareTo( object obj ) {
            if ( obj == null ) return 1;
            if ( !( obj is Timestamp ) ) throw new ArgumentException( "Object must be of type Timestamp" );

            return this.CompareTo( ( Timestamp )obj );
        }

        public int CompareTo( Timestamp other ) {
            return this.Value.CompareTo( other.Value );
        }

        #endregion


        #region Conversion Operators

        public static implicit operator Timestamp( string value ) {
            if ( string.IsNullOrWhiteSpace( "value" ) ) throw new ArgumentNullException( "value", "Value can not be null or whitespace" );

            long val = long.Parse( value );
            if ( val > uint.MaxValue ) {
                return val;
            }

            return new Timestamp( Convert.ToUInt32( value ) );
        }

        public static implicit operator Timestamp( long value ) {
            if ( value < 0 ) throw new ArgumentOutOfRangeException( "value", value, "Value must be >= 0" );

            if ( value > 1000 ) value = ( value / 1000 );

            return new Timestamp( Convert.ToUInt32( value ) );
        }

        public static implicit operator Timestamp( int value ) {
            if ( value < 0 ) throw new ArgumentOutOfRangeException( "value", value, "Value must be >= 0" );
            return new Timestamp( Convert.ToUInt32( value ) );
        }

        public static implicit operator DateTime( Timestamp value ) {
            return EpochStart.AddSeconds( value.Value ).ToUniversalTime();
        }

        public static implicit operator Timestamp( DateTime value ) {
            var seconds = ( value - EpochStart ).TotalSeconds;
            return new Timestamp( Convert.ToUInt32( seconds ) );
        }

        public static implicit operator Timestamp( TimeSpan value ) {
            return new DateTime( value.Ticks );
        }

        #endregion


    }
}
