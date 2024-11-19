using System;
using UnityEngine;

public class EnemyTargetDetector : MonoBehaviour
{
    [SerializeField] private float _detectionDistance = 4.5f;

    private bool _hasTarget;

    public event Action<Player> Detected;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _detectionDistance);

        if (_hasTarget == false && hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out Player target))
            {                              
                Detected?.Invoke(target);
                _hasTarget = true;
            }
        }
    }

    public void ClearTarget()
    {
        _hasTarget = false;        
    }
}
