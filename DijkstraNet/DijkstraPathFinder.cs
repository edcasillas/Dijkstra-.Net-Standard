using System;

namespace DijkstraNet {
	public class DijkstraPathFinder<TData, TWeight>
	{
		public WeightedPath<TData, TWeight> FindShortestPath(WeightedGraph<TData, TWeight> graph, TData from, TData to) {
			if(graph == null) throw new ArgumentNullException(nameof(graph));
			if (!graph.HasVertex(from)) throw new ArgumentException();
			if (!graph.HasVertex(to)) throw new ArgumentNullException();



			return null;
		}
	}
}
