using System;
using System.Linq;
using System.Collections.Generic;

public static class Program
{
	public static void Main()
	{
		var rnd = new BlueNoise2D(20, 20);
		var bits = rnd.Generate(0.25f);

		for (int y = 0; y < 20; y++)
		{
			for (int x = 0; x < 20; x++)
			{
				if (bits[x, y])
				{
					Console.Write(" +");
				}
				else
				{
					Console.Write("  ");
				}
			}
			Console.WriteLine();
		}
	}
}