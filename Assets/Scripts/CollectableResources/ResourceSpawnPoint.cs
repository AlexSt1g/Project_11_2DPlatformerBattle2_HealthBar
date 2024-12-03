using System.Collections;
using UnityEngine;

public class ResourceSpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private float _respawnTime = 20f;

    private Transform _resource; 
    private ICollectable _iCollectableComponent;
    private WaitForSeconds _waitRespawnTime;

    private void Awake()
    {
        _waitRespawnTime = new WaitForSeconds(_respawnTime);
    }

    private void OnDisable()
    {       
        if (_iCollectableComponent != null)
            _iCollectableComponent.Collected -= Respawn;
    }

    public void Spawn()
    {
        _resource = Instantiate(_prefab, transform.position, Quaternion.identity);

        if (_resource.TryGetComponent(out _iCollectableComponent))
            _iCollectableComponent.Collected += Respawn;
    }

    private void Respawn()
    {
        _resource.gameObject.SetActive(false);

        StartCoroutine(RespawnWithDelay());
    }

    private IEnumerator RespawnWithDelay()
    {
        yield return _waitRespawnTime;

        _resource.gameObject.SetActive(true);
    }
}
