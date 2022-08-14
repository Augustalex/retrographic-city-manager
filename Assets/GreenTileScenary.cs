using Tiles;
using UnityEngine;

public class GreenTileScenary : MonoBehaviour
{
    public TileSettings tileSettings;
    public GreenTileSettings greenTileSettings;

    // Private

    void Start()
    {
        var count = Random.Range(6f, 31f);
        var step = 1f / count;
        for (int i = 0; i < count; i++)
        {
            var tree = Instantiate(
                greenTileSettings.RandomTree(),
                transform.position + RandomOffset3d() * .5f * tileSettings.tileScale,
                Quaternion.identity,
                transform
            );
            tree.transform.localScale = .35f * RandomScale(tree.transform.localScale);


            // var tree = Instantiate(greenTileSettings.RandomTree(),
            //     transform.position +
            //     RandomOffset(0f + i * step, .1f + i * step) * .5f * tileSettings.tileScale,
            //     Quaternion.identity,
            //     transform);
            // tree.transform.localScale = .3f * RandomScale(tree.transform.localScale);
        }
    }

    private Vector3 RandomScale(Vector3 originalScale)
    {
        return originalScale * Random.Range(.6f, 1f);
    }

    private Vector3 RandomOffset3d()
    {
        var flat = Random.insideUnitCircle;
        return new Vector3(flat.x, 0f, flat.y);
    }

    private Vector3 RandomOffset(float start = 0f, float scale = 1f)
    {
        var rand = Random.insideUnitCircle;
        var mag = Random.Range(start, 1f);
        return rand.normalized * mag * scale;
    }
}