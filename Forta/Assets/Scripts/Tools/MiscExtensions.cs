using System.Collections.Generic;

namespace Forta.Tools
{
	public static class MiscExtensions 
	{
		/// <summary>
		/// Adds an item to a list then returns the index it was added to.
		/// </summary>
		/// <typeparam name="T">List type.</typeparam>
		/// <param name="list">Collection.</param>
		/// <param name="toAdd">Item to add.</param>
		/// <returns>Index the item was added to.</returns>
		public static int AddReturnIndex<T>(this List<T> list, T toAdd)
		{
			list.Add(toAdd);
			return list.Count - 1;
		}
	}
}