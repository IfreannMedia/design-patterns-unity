using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prototype spawner using own rolled instantiation of prototype (prefab) objects
public class PrototypeSpawnerOwnRolled : MonoBehaviour
{
    void Update()
    {
        if (Random.Range(0, 100) < 10)
            ProcCube.Clone(transform.position); // performant, cloning the originally created cube
        else if (Random.Range(0, 100) < 10)
            ProcSphere.Clone(transform.position);
        // ProcCube.CreateCube(this.transform.position); - non performant, many individual cubes
    }
}
