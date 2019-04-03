using System.Collections.Generic;

namespace DijkstraNet
{
	public class WeightedGraphNode<TData, TWeight>
	{
		public readonly TData Data;
		public readonly ICollection<WeightedEdge<TData, TWeight>> Edges = new List<WeightedEdge<TData, TWeight>>();

		public WeightedGraphNode(TData data)
		{
			Data = data;
		}
	}
}