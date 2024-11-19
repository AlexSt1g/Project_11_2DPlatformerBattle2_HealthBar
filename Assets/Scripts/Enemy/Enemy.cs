using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyTargetDetector))]
[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(EnemyAttacker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageablePerson
{
    private EnemyMover _mover;
    private EnemyTargetDetector _targetDetector;
    private EnemyAnimationController _animator;
    private EnemyAttacker _attacker;
    private Rigidbody2D _rigibody;
    private Player _target;
    private Transform _targetTransform;
    private Collider2D _targetCollider;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _targetDetector = GetComponent<EnemyTargetDetector>();
        _animator = GetComponent<EnemyAnimationController>();
        _attacker = GetComponent<EnemyAttacker>();
        _rigibody = GetComponent<Rigidbody2D>();        
        Health = MaxHealth;
    }

    private void OnEnable()
    {
        _targetDetector.Detected += TakeTarget;
        _attacker.Attacked += AnimateAttack;
    }

    private void OnDisable()
    {
        _targetDetector.Detected -= TakeTarget;
        _attacker.Attacked -= AnimateAttack;
    }

    private void Update()
    {
        if (IsDead == false)
        {
            if (_target)
            {
                if (GetTargetInAttackRangeStatus())
                {
                    if (_attacker.IsAttacking == false && _target.Health > 0)
                        _attacker.Attack(_target);
                }
                else if (_attacker.IsAttacking == false)
                {
                    _mover.FollowTarget(_targetTransform);
                }

                if (GetTargetInPatrolAreaStatus() == false)
                {
                    ClearTarget();

                    _attacker.EndAttack();
                }
            }
            else
            {
                _mover.Patrol();
            }

            _animator.UpdateMove(_mover.GetRunningStatus());
        }
    }

    public bool GetTargetInAttackRangeStatus()
    {
        return Physics2D.OverlapCircle(transform.position, _attacker.AttackRange) == _targetCollider;
    }

    public override void TakeHit(int damageValue)
    {
        _animator.TakeHit();

        base.TakeHit(damageValue);
    }

    public override void Revive()
    {
        base.Revive();
        
        _rigibody.simulated = true;
        
        _animator.SetLifeStatus(IsDead);
    }

    protected override void Die()
    {
        base.Die();

        _rigibody.simulated = false;

        _animator.SetLifeStatus(IsDead);
    }

    private void TakeTarget(Player target)
    {
        _target = target;
        _targetTransform = target.GetComponent<Transform>();
        _targetCollider = target.GetComponent<Collider2D>();
    }

    private void ClearTarget()
    {
        _target = null;
        _targetDetector.ClearTarget();
    }

    private void AnimateAttack()
    {
        if (IsDead == false)
            _animator.Attack();
    }

    private bool GetTargetInPatrolAreaStatus()
    {
        return Physics2D.OverlapArea(_mover.GetFirstWaypoint().position, _mover.GetLastWaypoint().position) == _targetCollider;
    }
}
