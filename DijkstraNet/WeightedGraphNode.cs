using System.Collections.Generic;

namespace DijkstraNet
{
	public class WeightedGraphNode<TData>
	{
		public readonly TData Data;
		public readonly ICollection<WeightedEdge<TData>> Edges = new List<WeightedEdge<TData>>();

		public WeightedGraphNode(TData data)
		{
			Data = data;
		}
	}
}