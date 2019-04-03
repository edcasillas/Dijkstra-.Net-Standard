namespace DijkstraNet
{
	public class WeightedEdge<TData, TWeight>
	{
		public readonly WeightedGraphNode<TData, TWeight> From;
		public readonly WeightedGraphNode<TData, TWeight> To;

		public readonly TWeight Weight;

		public WeightedEdge(WeightedGraphNode<TData, TWeight> from, WeightedGraphNode<TData, TWeight> to, TWeight weight)
		{
			From = from;
			To = to;
			Weight = weight;
		}
	}
}