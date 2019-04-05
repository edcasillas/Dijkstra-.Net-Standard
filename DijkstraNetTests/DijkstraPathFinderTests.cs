using System.Linq;
using DijkstraNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DijkstraNetTests {
	[TestClass]
	public class DijkstraPathFinderTests {
		[TestMethod]
		public void DijkstraPathFinder_FindShortestPath_Success() {
			// Arrange
			var graph = new WeightedGraph<char>();
			graph.AddEdge('A', 'B', 3);
			graph.AddEdge('A', 'C', 2);
			graph.AddEdge('A', 'D', 1);
			graph.AddEdge('D', 'C', 4);
			graph.AddEdge('D', 'G', 5);
			graph.AddEdge('C', 'G', 2);
			graph.AddEdge('B', 'E', 3);
			graph.AddEdge('E', 'F', 1);
			graph.AddEdge('E', 'H', 4);
			graph.AddEdge('F', 'G', 1);
			graph.AddEdge('F', 'H', 2);
			graph.AddEdge('G', 'H', 2);

			var pathFinder = new DijkstraPathFinder<char>();

			var result = pathFinder.FindShortestPath(graph, 'A', 'H');

			Assert.AreEqual(6, result.TotalCost);
			Assert.AreEqual(4, result.Path.Count());
			Assert.AreEqual('A',result.Path.ElementAt(0));
			Assert.AreEqual('C',result.Path.ElementAt(1));
			Assert.AreEqual('G',result.Path.ElementAt(2));
			Assert.AreEqual('H',result.Path.ElementAt(3));
		}
	}
}
