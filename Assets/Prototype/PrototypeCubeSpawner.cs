using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeCubeSpawner : MonoBehaviour
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
