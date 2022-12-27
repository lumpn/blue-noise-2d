using System;

public sealed class FairRandomizer
{
    private float entropy = 0;
    private Random rnd = new Random(42);

    public bool Random(float probability)
    {
        // handle edge cases
        if (probability <= 0)
        {
            return false;
        }
        if (probability >= 1)
        {
            return true;
        }

        // randomize with entropy
        entropy += probability;
        if (entropy > rnd.NextDouble())
        {
            entropy -= 1;
            return true;
        }
        return false;
    }
}
