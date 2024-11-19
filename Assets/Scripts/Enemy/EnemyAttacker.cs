using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 25;    
    [SerializeField] private float _attackDelay = 1.5f;

    private Enemy _enemy;
    private Coroutine _coroutine;

    public event Action Attacked;
    
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;

    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void Attack(Player target)
    {
        _coroutine = StartCoroutine(AttackWithDelay(target));
    }

    public void EndAttack()
    {
        IsAttacking = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator AttackWithDelay(Player target)
    {
        IsAttacking = true;    

        yield return new WaitForSeconds(_attackDelay);

        Attacked?.Invoke();        

        if (_enemy.IsDead == false && _enemy.GetTargetInAttackRangeStatus())
            target.TakeHit(_damage);

        IsAttacking = false;
    }
}
