using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;

    private int _currentWaypoint = 0;
    private Vector2 _currentPosition;

    private void Update()
    {
        TurnInMovingDirection();

        _currentPosition = transform.position;
    }

    public void Patrol()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    public void FollowTarget(Transform targetTransform)
    {
        Vector2 targetPositionHorizontal = new(targetTransform.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPositionHorizontal, _speed * Time.deltaTime);
    }

    public bool GetRunningStatus()
    {
        return _currentPosition.x != transform.position.x;
    }

    private void TurnInMovingDirection()
    {
        float turnLeftYAxisDegreese = 180;
        float turnRightYAxisDegreese = 0;

        if (transform.position.x < _currentPosition.x)
            transform.rotation = Quaternion.Euler(0, turnLeftYAxisDegreese, 0);
        else if (transform.position.x > _currentPosition.x)
            transform.rotation = Quaternion.Euler(0, turnRightYAxisDegreese, 0);
    }
}
