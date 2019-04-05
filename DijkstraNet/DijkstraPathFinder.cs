using System;
using System.Collections.Generic;

namespace DijkstraNet {
	public class DijkstraPathFinder<TData>
	{
		public WeightedPath<TData> FindShortestPath(WeightedGraph<TData> graph, TData from, TData to) {
			if (graph == null) throw new ArgumentNullException(nameof(graph));
			if (!graph.HasVertex(from)) throw new ArgumentException();
			if (!graph.HasVertex(to)) throw new ArgumentNullException();

			var confirmed = new Dictionary<TData, WeightedPathNode<TData>>();
			var tentative = new Dictionary<TData, WeightedPathNode<TData>>();
			var queue = new MinPriorityQueue<WeightedPathNode<TData>>();

			queue.Enqueue(new WeightedPathNode<TData> {
				Cost = 0f,
				Data = from,
				Previous = default(TData)
			});

			while (!queue.IsEmpty()) {
				var currentNode = queue.Dequeue();
				confirmed.Add(currentNode.Data, currentNode);
				if (currentNode.Data.Equals(to)) break;
				foreach(var sibling in graph.GetEdgesFrom(currentNode.Data))
				{
					if(confirmed.ContainsKey(sibling.To)) continue;

					if (tentative.ContainsKey(sibling.To)) {
						var newCost = currentNode.Cost + sibling.Weight;
						if (newCost < tentative[sibling.To].Cost) {
							tentative[sibling.To].Cost = newCost;
							tentative[sibling.To].Previous = currentNode.Data;
						}
					}
					else {
						var newPathNode = new WeightedPathNode<TData> {
							Data = sibling.To,
							Previous = currentNode.Data,
							Cost = currentNode.Cost + sibling.Weight
						};
						tentative.Add(sibling.To, newPathNode);
						queue.Enqueue(newPathNode);
					}
				}
			}

			if (!confirmed.ContainsKey(to)) return null;

			var result = new WeightedPath<TData> {
				TotalCost = confirmed[to].Cost
			};

			var pathStack = new Stack<TData>();
			var nextInPath = to;
			while (!nextInPath.Equals(default(TData))) {
				pathStack.Push(nextInPath);
				nextInPath = confirmed[nextInPath].Previous;
			}

			var pathList = new List<TData>();
			while (pathStack.Count > 0) {
				pathList.Add(pathStack.Pop());
			}

			result.Path = pathList;

			return result;
		}
	}
}