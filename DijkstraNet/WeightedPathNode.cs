using System;

namespace DijkstraNet {
	public class WeightedPathNode<TData, TWeight> : IComparable<WeightedPathNode<TData,TWeight>>
		where TWeight : IComparable<TWeight>
	{
		public TData Data;
		public TData Previous;
		public TWeight Cost;

		public int CompareTo(WeightedPathNode<TData, TWeight> other) => Cost.CompareTo(other.Cost);
	}
}