using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 25;    
    [SerializeField] private float _attackDelay = 1.5f;
    [SerializeField] private EnemyAttackRangeScanner _attackRangeScanner;

    private Enemy _enemy;
    private Coroutine _coroutine;
    private WaitForSeconds _waitAttackDelay;

    public event Action Attacked;    

    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _waitAttackDelay = new WaitForSeconds(_attackDelay);
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

        yield return _waitAttackDelay;

        Attacked?.Invoke();        

        if (_enemy.IsDead == false && _attackRangeScanner.IsAttackEnable)
            target.TakeHit(_damage);

        IsAttacking = false;
    }
}
