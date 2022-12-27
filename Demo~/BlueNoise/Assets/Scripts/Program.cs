using System;

public static class Program
{
    public static void Main()
    {
        var sizeX = 20;
        var sizeY = 20;
        var probability = 0.25f;
        var seed = 42;

        var rnd = new BlueNoise2D(sizeX, sizeY, seed);
        var bits = rnd.Generate(probability);

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
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
