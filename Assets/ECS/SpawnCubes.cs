using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cube;
    public int width, depth;

    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                GameObject instance = Instantiate(cube, new Vector3(x, Mathf.PerlinNoise(x * .2f, z * .2f), z), Quaternion.identity);
            }
        }
    }

}
