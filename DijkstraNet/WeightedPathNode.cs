using System;

namespace DijkstraNet {
	public class WeightedPathNode<TData> : IComparable<WeightedPathNode<TData>>
	{
		public TData Data;
		public TData Previous;
		public float Cost;

		public int CompareTo(WeightedPathNode<TData> other) => Cost.CompareTo(other.Cost);
	}
}