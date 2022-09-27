using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public GameObject eggPrefab;
    public GameObject medpackPrefab;
    public Terrain terrain;

    private TerrainData terrainData;

    private void Start()
    {

        terrainData = terrain.terrainData;
        InvokeRepeating("CreateEgg", 1, 1f);
        InvokeRepeating("CreateMedpack", 1, 0.1f);
    }

    private void CreateEgg()
    {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terrain.SampleHeight(pos) + 10;
        GameObject egg = Instantiate(eggPrefab, pos, Quaternion.identity);
    }

    private void CreateMedpack()
    {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terrain.SampleHeight(pos) + 10;
        GameObject egg = Instantiate(medpackPrefab, pos, Quaternion.identity);
    }

}
