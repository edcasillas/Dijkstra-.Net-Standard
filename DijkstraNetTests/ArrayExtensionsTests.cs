using System;
using DijkstraNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DijkstraNetTests
{
	[TestClass]
	public class ArrayExtensionsTests
	{
		[TestMethod]
		public void ArrayExtensions_MinHeapify_Success()
		{
			// Arrange
			var array = new int[Faker.RandomNumber.Next(20, 100)];
			for (int i = 0; i < array.Length; i++) array[i] = Faker.RandomNumber.Next();

			// Act
			array.MinHeapify();

			// Assert
			Assert.IsTrue(isMinHeap(array));
		}

		[TestMethod]
		public void ArrayExtensions_Swap_Success()
		{
			// Arrange
			var array = new int[Faker.RandomNumber.Next(20, 100)];
			for (int i = 0; i < array.Length; i++) array[i] = Faker.RandomNumber.Next();
			var a = Faker.RandomNumber.Next(0, array.Length);
			var b = Faker.RandomNumber.Next(0, array.Length);

			var initialDataInI = array[a];
			var initialDataInJ = array[b];

			// Act
			array.Swap(a, b);

			// Assert
			Assert.AreEqual(initialDataInJ, array[a]);
			Assert.AreEqual(initialDataInI, array[b]);
		}

		private bool isMinHeap<T>(T[] array, int index = 0)
			where T : IComparable<T>
		{
			if (array == null) throw new ArgumentNullException();
			if (index < 0) throw new ArgumentException();
			if (array.Length == 0 || index >= array.Length) return true;

			var leftIndex = 2 * index + 1;
			var rightIndex = leftIndex + 1;

			return
				(leftIndex >= array.Length || array[index].CompareTo(array[leftIndex]) <= 0) &&
				(rightIndex >= array.Length || array[index].CompareTo(array[rightIndex]) <= 0) &&
				isMinHeap(array, leftIndex) &&
				isMinHeap(array, rightIndex);
		}
	}
}