using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAttackRangeScanner : MonoBehaviour
{
    private CircleCollider2D _collider;

    public bool IsAttackEnable { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))        
            IsAttackEnable = true;            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))        
            IsAttackEnable = false;            
    }
}
