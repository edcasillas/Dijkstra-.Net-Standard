using System;
using System.Collections.Generic;

namespace DijkstraNet {
	public class DijkstraPathFinder<TData, TWeight>
		where TWeight : IComparable<TWeight>
	{
		public WeightedPath<TData, TWeight> FindShortestPath(WeightedGraph<TData, TWeight> graph, TData from, TData to) {
			if (graph == null) throw new ArgumentNullException(nameof(graph));
			if (!graph.HasVertex(from)) throw new ArgumentException();
			if (!graph.HasVertex(to)) throw new ArgumentNullException();

			var confirmed = new Dictionary<TData, WeightedPathNode<TData, TWeight>>();
			var tentative = new Dictionary<TData, WeightedPathNode<TData, TWeight>>();
			var queue = new MinPriorityQueue<WeightedPathNode<TData, TWeight>>();

			return null;
		}
	}
}