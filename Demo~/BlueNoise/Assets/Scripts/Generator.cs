using UnityEngine;

public sealed class Generator : MonoBehaviour
{
    [SerializeField] private GameObject primitiveZero, primitiveOne;
    [SerializeField] private float probability;

    [ContextMenu(nameof(Start))]
    protected void Start()
    {
        Spawn(100, 100, probability, Random.Range(0, 1000000));
    }

    private void Spawn(int sizeX, int sizeY, float probability, int seed)
    {
        var rnd = new BlueNoise2D(sizeX, sizeY, seed);
        var bits = rnd.Generate(probability);

        var go = new GameObject();
        var parent = go.transform;
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var primitive = (bits[x, y] ? primitiveOne : primitiveZero);
                Object.Instantiate(primitive, new Vector3(x, 0, y), Quaternion.identity, parent);
            }
        }
    }
}
