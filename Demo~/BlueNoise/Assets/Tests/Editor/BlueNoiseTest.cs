using System.Text;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public sealed class BlueNoiseTest
{
    [Test]
    public void Test1()
    {
        Print(20, 20, 0.5f, 1);
    }

    [Test]
    public void Test2()
    {
        Print(20, 20, 0.5f, 2);
    }

    [Test]
    public void Test3()
    {
        Print(20, 20, 0.5f, 3);
    }


    private void Print(int sizeX, int sizeY, float probability, int seed)
    {
        var rnd = new BlueNoise2D(sizeX, sizeY, seed);
        var bits = rnd.Generate(probability);

        var sb = new StringBuilder();
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                if (bits[x, y])
                {
                    sb.Append("  +");
                }
                else
                {
                    sb.Append("   ");
                }
            }
            sb.AppendLine();
        }

        Debug.Log(sb);
    }

    [Test]
    public void Test4()
    {
        var sizeX = 10;
        var sizeY = 10;
        var probability = 0.1f;
        var entropy = CalculateEntropy(sizeX, sizeY, probability);

        var sb = new StringBuilder();
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                sb.AppendFormat("{0:F3},  ", entropy[x, y]);
            }
            sb.AppendLine();
        }

        Debug.Log(sb);
    }

    private static float[,] CalculateEntropy(int sizeX, int sizeY, float probability)
    {
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
                entropies[x, y] = entropy;

                //if (x < sizeX - 1 && y < sizeY - 1)
                //{
                //    entropies[x + 1, y + 1] -= entropy;
                //}
            }
        }
        return entropies;
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
