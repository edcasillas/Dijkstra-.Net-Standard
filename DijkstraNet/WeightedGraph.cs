using System;
using System.Collections.Generic;

namespace DijkstraNet
{
	public class WeightedGraph<TData, TWeight>
	{
		private readonly IDictionary<TData, ICollection<WeightedEdge<TData, TWeight>>> vertices = new Dictionary<TData, ICollection<WeightedEdge<TData, TWeight>>>();
		//private readonly ICollection<WeightedEdge<TData, TWeight>> edges = new List<WeightedEdge<TData, TWeight>>();

		public void AddVertex(TData data)
		{
			if(vertices.ContainsKey(data)) throw new InvalidOperationException("Data already exists in the graph.");
			vertices.Add(data, new List<WeightedEdge<TData, TWeight>>());
		}

		public void AddEdge(TData from, TData to, TWeight weight, bool directed = true)
		{
			if(!vertices.ContainsKey(from)) AddVertex(from);
			if (!vertices.ContainsKey(to)) AddVertex(to);
			vertices[from].Add(new WeightedEdge<TData,TWeight>(from, to, weight));
			if (!directed) AddEdge(to, from, weight);
		}

		public bool HasVertex(TData data) => vertices.ContainsKey(data);
	}
}