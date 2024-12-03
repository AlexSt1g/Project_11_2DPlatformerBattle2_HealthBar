using System;
using UnityEngine;

public class EnemyTargetDetector : MonoBehaviour
{
    public event Action<Player> Detected;
    public event Action Lost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player target))
            Detected?.Invoke(target);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
            Lost?.Invoke();
    }    
}
