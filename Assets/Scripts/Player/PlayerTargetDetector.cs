using UnityEngine;

public class PlayerTargetDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;    

    public bool TryGetTarget(float attackRange, out Enemy target)
    {
        Collider2D other = Physics2D.OverlapCircle(transform.position, attackRange, _targetLayer);

        if (other != null)
        {
            return other.TryGetComponent<Enemy>(out target);
        }
        else
        {
            target = null;
            return false;
        }
    }
}
