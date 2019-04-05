namespace DijkstraNet
{
	public class WeightedEdge<TData>
	{
		public readonly TData From;
		public readonly TData To;

		public readonly float Weight;

		public WeightedEdge(TData from, TData to, float weight)
		{
			From = from;
			To = to;
			Weight = weight;
		}
	}
}