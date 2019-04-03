using System.Collections.Generic;

namespace DijkstraNet
{
	public class UnweightedGraphNode<T>
	{
		public T Data;
		public ICollection<UnweightedGraphNode<T>> Siblings;
	}
}
