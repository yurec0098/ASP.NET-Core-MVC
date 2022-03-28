using System;
using System.Collections.Generic;

namespace Lesson1
{
	internal class LastAsync<T> : List<T> where T : class
	{
		private readonly object _lock = new object();
		public new void Add(T item)
		{
			lock (_lock)
				base.Add(item);
		}
		public new void AddRange(IEnumerable<T> collection)
		{
			lock (_lock)
				base.AddRange(collection);
		}
		public new void Clear()
		{
			lock (_lock)
				base.Clear();
		}
		public new bool Remove(T item)
		{
			lock (_lock)
				return base.Remove(item);
		}
		public new int RemoveAll(Predicate<T> match)
		{
			lock (_lock)
				return base.RemoveAll(match);
		}
		public new void RemoveAt(int index)
		{
			lock (_lock)
				base.RemoveAt(index);
		}
		public new void RemoveRange(int index, int count)
		{
			lock (_lock)
				base.RemoveRange(index, count);
		}
		public new void CopyTo(T[] array, int arrayIndex)
		{
			lock (_lock)
				base.CopyTo(array, arrayIndex);
		}
		public new void CopyTo(T[] array)
		{
			lock (_lock)
				base.CopyTo(array);
		}
		public new void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			lock (_lock)
				base.CopyTo(index, array, arrayIndex, count);
		}
	}
}
