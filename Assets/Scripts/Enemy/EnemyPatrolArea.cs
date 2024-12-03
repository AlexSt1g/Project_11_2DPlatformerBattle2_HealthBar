using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyPatrolArea : MonoBehaviour
{
    [SerializeField] private Transform _firstWaypoint;
    [SerializeField] private Transform _lastWaypoint;

    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = true;
    }

    private void Start()
    {
        float halfDivider = 2;
        Vector2 centerOfPatrolArea = (_firstWaypoint.position + _lastWaypoint.position) / halfDivider;
        float patrolAreaWidth = (_firstWaypoint.position - _lastWaypoint.position).magnitude;

        transform.position = centerOfPatrolArea;

        _collider.size = new Vector2(patrolAreaWidth, _collider.size.y);
    }
}
