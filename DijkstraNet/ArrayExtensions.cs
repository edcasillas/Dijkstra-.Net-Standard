using System;

namespace DijkstraNet
{
	public static class ArrayExtensions
	{
		public static void MinHeapify<T>(this T[] array, int count = 0)
			where T : IComparable<T>
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (count < 0 || count > array.Length) throw new ArgumentException();

			if (count == 0) count = array.Length;
			for (int i = count / 2; i >= 0; i--) array.MinHeapifyDown(i, count);
		}

		public static void MinHeapifyDown<T>(this T[] array, int index, int count)
			where T : IComparable<T>
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (index < 0 || index >= count || count < 0 || count > array.Length) throw new ArgumentException();

			var min = index;
			var left = 2 * index + 1;
			var right = left + 1;

			if (left < count && array[min].CompareTo(array[left]) > 0) min = left;
			if (right < count && array[min].CompareTo(array[right]) > 0) min = right;

			if (min != index)
			{
				array.Swap(min, index);
				array.MinHeapifyDown(min, count);
			}
		}

		public static void MinHeapifyUp<T>(this T[] array, int index)
			where T : IComparable<T>
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (index < 0 || index >= array.Length) throw new ArgumentException();

			if (index == 0) return;

			var parent = (index - 1) / 2;

			if (array[parent].CompareTo(array[index]) > 0)
			{
				array.Swap(parent,index);
				array.MinHeapifyUp(parent);
			}
		}

		public static void Swap<T>(this T[] array, int i, int j)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (i < 0 || j < 0 || i >= array.Length || j >= array.Length) throw new ArgumentException();

			var aux = array[i];
			array[i] = array[j];
			array[j] = aux;
		}

		public static T[] DoubleCapacity<T>(this T[] array)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			var result = new T[array.Length * 2];

			for (int i = 0; i < array.Length; i++) result[i] = array[i];
			return result;
		}
	}
}
