using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public struct DfsVertice<T> : IEquatable<DfsVertice<T>>
        where T : IEquatable<T>
    {
        public DfsVertice(T vertice, T predescessor)
        {
            Vertice = vertice;
            Predescessor = predescessor;
            DiscoveredTimestamp = int.MaxValue;
            TraversedTimestamp = int.MinValue;
        }

        public T Vertice { get; set; }
        public int DiscoveredTimestamp { get; set; }
        public int TraversedTimestamp { get; set; }
        public T Predescessor { get; set; }

        public bool Equals(DfsVertice<T> other)
        {
            var comparer = EqualityComparer<T>.Default;

            return
                comparer.Equals(this.Vertice, other.Vertice) &&
                comparer.Equals(this.Predescessor, other.Predescessor) &&
                this.DiscoveredTimestamp == other.DiscoveredTimestamp &&
                this.TraversedTimestamp == other.TraversedTimestamp;
        }

        public override bool Equals(object obj)
        {
            if (obj is DfsVertice<T>) return Equals((DfsVertice<T>)obj);
            else return false;
        }

        public override int GetHashCode()
        {
            return
                (Vertice?.GetHashCode() ?? 0) ^
                (Predescessor?.GetHashCode() ?? 0) ^
                DiscoveredTimestamp.GetHashCode() ^ 
                TraversedTimestamp.GetHashCode();
        }

        public static bool operator ==(DfsVertice<T> left, DfsVertice<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DfsVertice<T> left, DfsVertice<T> right)
        {
            return !(left == right);
        }
    }
}
