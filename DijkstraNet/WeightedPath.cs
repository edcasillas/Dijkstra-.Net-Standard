using System.Collections.Generic;

namespace DijkstraNet {
	public class WeightedPath<TData, TWeight> {
		public TWeight Distance;
		public IEnumerable<TData> Path;
	}
}