using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{    
    [SerializeField] private Transform _spawnPointsParent;    
    
    private ResourceSpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new ResourceSpawnPoint[_spawnPointsParent.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            if (_spawnPointsParent.GetChild(i).TryGetComponent(out ResourceSpawnPoint spawnPoint))
                _spawnPoints[i] = spawnPoint;
    }

    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
            spawnPoint.Spawn();
    }
}
