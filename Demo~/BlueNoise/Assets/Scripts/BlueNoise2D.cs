using System;

public sealed class BlueNoise2D
{
    private readonly int sizeX, sizeY;
    private readonly Random rnd;

    public BlueNoise2D(int sizeX, int sizeY, int seed)
    {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        this.rnd = new Random(seed);
    }

    public bool[,] Generate(float probability)
    {
        var result = new bool[sizeX, sizeY];
        var entropies = new float[sizeX, sizeY];
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var entropy = 0f;
                if (x > 0)
                {
                    entropy += entropies[x - 1, y];
                }
                if (y > 0)
                {
                    entropy += entropies[x, y - 1];
                }

                var bit = Random(probability, ref entropy);
                result[x, y] = bit;
                entropies[x, y] = entropy;
            }
        }
        return result;
    }

    private static bool Random(float probability, ref float entropy)
    {
        entropy += probability;
        if (entropy >= 0.5f)
        {
            entropy -= 1;
            return true;
        }
        return false;
    }
}
