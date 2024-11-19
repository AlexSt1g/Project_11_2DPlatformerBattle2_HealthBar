using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 50;
    
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;

    public void Attack(Enemy target)
    {        
        target.TakeHit(_damage);
    }
}
