using System.Collections.Generic;
using DijkstraNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DijkstraNetTests
{
	[TestClass]
	public class MinPriorityQueueTests
	{
		[TestMethod]
		public void MinPriorityQueue_FullTest_Successful()
		{
			var source = new List<int>();
			var sourceCount = Faker.RandomNumber.Next(20, 100);
			for (int i = 0; i < sourceCount; i++) source.Add(Faker.RandomNumber.Next());

			var additionalDataCount = Faker.RandomNumber.Next(10, 50);

			// Act 1. Build priority queue with some initial data.
			var queue = new MinPriorityQueue<int>(source);

			// Act 2. Add some additional data using Enqueue
			for (int i = 0; i < additionalDataCount; i++)
			{
				queue.Enqueue(Faker.RandomNumber.Next());
			}

			// Act 3 & Assert - Check results from the queue
			var prev = -1; // Set a negative number as previous; all data in the queue is assumed to be positive.
			while (!queue.IsEmpty())
			{
				var curr = queue.Dequeue();
				Assert.IsTrue(curr >= prev);
				prev = curr;
			}
		}
	}
}
