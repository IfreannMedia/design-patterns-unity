using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[CustomEditor (typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor
{
    string path;
    string assetPath;
    string fileName;

    private void OnEnable()
    {
        path = Application.dataPath + "/Prototype/asteroids/generated";
        assetPath = "Assets/Prototype/asteroids/generated";
        fileName = "asteroid_" + System.DateTime.Now.Ticks.ToString();
    }

    public override void OnInspectorGUI()
    {
        AsteroidSpawner astSpawner = (AsteroidSpawner)target;
        DrawDefaultInspector();
        if(GUILayout.Button("Create Asteroid"))
        {
            astSpawner.CreateAsteroid();
        }
        if (GUILayout.Button("Save Asteroid"))
        {
            Directory.CreateDirectory(path);
            Mesh mesh = astSpawner.asteroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetPath + "/" + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(astSpawner.asteroid, assetPath +"/"+ fileName + ".prefab");
        }
    }
}
