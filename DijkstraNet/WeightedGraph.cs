using System;
using System.Collections.Generic;

namespace DijkstraNet
{
	public class WeightedGraph<TData, TWeight>
	{
		private readonly IDictionary<TData, WeightedGraphNode<TData, TWeight>> nodes = new Dictionary<TData, WeightedGraphNode<TData, TWeight>>();
		private readonly ICollection<WeightedEdge<TData, TWeight>> edges = new List<WeightedEdge<TData, TWeight>>();

		public void AddNode(TData data)
		{
			if(nodes.ContainsKey(data)) throw new InvalidOperationException("Data already exists in the graph.");
			nodes.Add(data, new WeightedGraphNode<TData, TWeight>(data));
		}

		public void AddEdge(TData from, TData to, TWeight weight, bool directed = true)
		{
			if(!nodes.ContainsKey(from)) AddNode(from);
			if (!nodes.ContainsKey(to)) AddNode(to);
			nodes[from].Edges.Add(new WeightedEdge<TData,TWeight>(nodes[from], nodes[to], weight));
			if (!directed) AddEdge(to, from, weight);
		}
	}
}