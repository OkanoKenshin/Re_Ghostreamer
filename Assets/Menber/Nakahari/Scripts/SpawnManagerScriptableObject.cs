using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public List<SpawnDate> spawnDateList = new List<SpawnDate>();

    /*public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;*/
}

[System.Serializable]
public class SpawnDate
{
    public Vector3 position;
    public Quaternion rotation;

    public string prefabName;
    public int numberOfPrefabsToCreate;
}