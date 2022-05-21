using System;

namespace Forta.Tools
{
	public class SingletonNotFoundException : Exception
	{
		public SingletonNotFoundException(string message) : base(message)
		{
		}

		public SingletonNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public SingletonNotFoundException()
		{
		}
	}
}