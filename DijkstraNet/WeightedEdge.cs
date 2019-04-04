namespace DijkstraNet
{
	public class WeightedEdge<TData, TWeight>
	{
		public readonly TData From;
		public readonly TData To;

		public readonly TWeight Weight;

		public WeightedEdge(TData from, TData to, TWeight weight)
		{
			From = from;
			To = to;
			Weight = weight;
		}
	}
}