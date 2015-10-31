using System;
using System.Threading;

namespace Multithreading
{
	public class Program
	{
		static volatile bool cancelThread = false;

		static void Main(string[] args)
		{
			Thread th = new Thread(SayHello);
			th.Name = "Hello";
			th.Priority = ThreadPriority.Normal;
			th.Start("Calin");
			Console.ReadLine ();

			cancelThread = true;
			th.Join ();
			Console.WriteLine ("I am the main threat");
			Console.ReadLine ();
		}

		private static void SayHello (object name)
		{
			while (!cancelThread) 
			{
				Console.WriteLine ("Hello " + (string)name);
			}
		}
	}
}

