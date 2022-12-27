using System;
using System.Linq;
using System.Collections.Generic;

public sealed class BlueNoise2D
{
	private readonly int sizeX, sizeY;
	private readonly Random rnd = new Random(42);

	public BlueNoise2D(int sizeX, int sizeY)
	{
		this.sizeX = sizeX;
		this.sizeY = sizeY;
	}

	public bool[,] Generate(float probability)
	{
		var result = new bool[sizeX, sizeY];
		var entropies = new float[sizeX, sizeY];
		for (int y = 0; y < sizeY; y++)
		{
			for (int x = 0; x < sizeX; x++)
			{
				var entropy = entropies[x, y];
				var bit = Random(probability, ref entropy);
				result[x, y] = bit;

				if (x < sizeX - 1) entropies[x + 1, y] += entropy * 2 / 5;
				if (y < sizeY - 1) entropies[x, y + 1] += entropy * 2 / 5;
				if (x < sizeX - 1 && y < sizeY - 1) entropies[x + 1, y + 1] += entropy / 5;
			}
		}
		return result;
	}

	private bool Random(float probability, ref float entropy)
	{
		entropy += probability;
		//	if (entropy > rnd.NextDouble())
		if (entropy > 0.5f)
		{
			entropy -= 1;
			return true;
		}
		return false;
	}
}
