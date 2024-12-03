using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private float _respawnDelay = 5f;

    private Player _player;
    private Vector2 _startPosition;
    private WaitForSeconds _waitRespawnDelay;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _waitRespawnDelay = new WaitForSeconds(_respawnDelay);
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _player.Died += Respawn;
    }

    private void OnDisable()
    {
        _player.Died -= Respawn;
    }

    private void Respawn()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return _waitRespawnDelay;

        transform.position = _startPosition;
        _player.Revive();
    }
}
