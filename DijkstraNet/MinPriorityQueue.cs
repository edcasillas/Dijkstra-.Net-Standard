using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraNet
{
	public class MinPriorityQueue<T>
		where T : IComparable<T>
	{
		private const int defaultCapacity = 2;
		private const float maxFillRatio = .85f;

		private T[] data;
		private int count;

		public MinPriorityQueue(IEnumerable<T> source)
		{		
			if (source == null || !source.Any())
			{
				count = 0;
				data = new T[defaultCapacity];
				return;
			}

			count = source.Count();
			data = source.ToArray();

			data.MinHeapify();
		}

		public bool IsEmpty() => data == null || !data.Any() || count == 0;

		public T Peek() => !IsEmpty() ? data[0] : default(T);

		public T Dequeue()
		{
			if(IsEmpty()) throw new InvalidOperationException();
			var result = Peek();
			data[0] = data[--count];
			data.MinHeapifyDown(0, count);
			return result;
		}

		public void Enqueue(T value)
		{
			if (data == null) data = new T[defaultCapacity];
			if (((float)count / (float)data.Length) >= maxFillRatio) data = data.DoubleCapacity();

			data[count] = value;
			data.MinHeapifyUp(count++);
		}
	}
}