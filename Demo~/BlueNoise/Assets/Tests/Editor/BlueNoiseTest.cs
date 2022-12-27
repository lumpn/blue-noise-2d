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
}
