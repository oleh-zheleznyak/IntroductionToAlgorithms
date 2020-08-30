using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public struct BfsVertice<T> : IEquatable<BfsVertice<T>>
        where T : IEquatable<T>
    {
        public BfsVertice(T vertice, T predescessor, int distance)
        {
            Vertice = vertice;
            Predescessor = predescessor;
            Distance = distance;
        }

        public T Vertice { get; set; }
        public int Distance { get; set; }
        public T Predescessor { get; set; }

        public bool Equals(BfsVertice<T> other)
        {
            var comparer = EqualityComparer<T>.Default;

            return 
                comparer.Equals(this.Vertice, other.Vertice) && 
                comparer.Equals(this.Predescessor, other.Predescessor) && 
                this.Distance == other.Distance;
        }

        public override bool Equals(object obj)
        {
            if (obj is BfsVertice<T>) return Equals((BfsVertice<T>)obj);
            else return false;
        }

        public override int GetHashCode()
        {
            return
                (Vertice?.GetHashCode() ?? 0) ^
                (Predescessor?.GetHashCode() ?? 0) ^
                Distance.GetHashCode();
        }

        public static bool operator ==(BfsVertice<T> left, BfsVertice<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BfsVertice<T> left, BfsVertice<T> right)
        {
            return !(left == right);
        }
    }
}