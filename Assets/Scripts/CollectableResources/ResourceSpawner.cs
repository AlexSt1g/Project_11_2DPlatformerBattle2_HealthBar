using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private List<ResourceSpawnPoint> _spawnPoints = new();

    private void Awake()
    {
        GetComponentsInChildren(_spawnPoints);
    }

    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
            spawnPoint.Spawn();
    }
}
