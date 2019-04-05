using System.Collections.Generic;

namespace DijkstraNet {
	public class WeightedPath<TData> {
		public float TotalCost;
		public IEnumerable<TData> Path;
	}
}