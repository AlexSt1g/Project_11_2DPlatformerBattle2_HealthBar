using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _respawnDelay = 30f;

    private Enemy _enemy;
    private Vector2 _startPosition;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _enemy.Died += Respawn;
    }

    private void OnDisable()
    {
        _enemy.Died -= Respawn;
    }

    private void Respawn()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(_respawnDelay);        

        transform.position = _startPosition;
        _enemy.Revive();
    }
}
