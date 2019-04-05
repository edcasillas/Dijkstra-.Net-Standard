using System;
using System.Collections.Generic;

namespace DijkstraNet {
	public class WeightedGraph<TData> {
		private readonly IDictionary<TData, ICollection<WeightedEdge<TData>>> vertices = new Dictionary<TData, ICollection<WeightedEdge<TData>>>();

		public void AddVertex(TData data) {
			if (vertices.ContainsKey(data)) throw new InvalidOperationException("Data already exists in the graph.");
			vertices.Add(data, new List<WeightedEdge<TData>>());
		}

		public void AddEdge(TData from, TData to, float weight, bool directed = false) {
			if (!vertices.ContainsKey(from)) AddVertex(from);
			if (!vertices.ContainsKey(to)) AddVertex(to);
			vertices[from].Add(new WeightedEdge<TData>(from, to, weight));
			if (!directed) AddEdge(to, from, weight, true);
		}

		public bool HasVertex(TData data) => vertices.ContainsKey(data);

		public IEnumerable<WeightedEdge<TData>> GetEdgesFrom(TData vertex) {
			if (!HasVertex(vertex)) return null;
			return vertices[vertex];
		}
	}
}