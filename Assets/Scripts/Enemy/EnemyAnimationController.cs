using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += Die;
    }

    private void OnDisable()
    {
        _enemy.Died -= Die;
    }

    public void UpdateMove(bool isRunning)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsRunning, isRunning);
    }

    public void Attack()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Attack);
    }

    public void TakeHit()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.TakeHit);
    }

    public void SetLifeStatus(bool isDead)
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsDead, isDead);
    }

    private void Die()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Die);
    }
}
