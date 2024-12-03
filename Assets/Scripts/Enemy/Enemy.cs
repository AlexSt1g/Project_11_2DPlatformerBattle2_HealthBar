using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(EnemyAttacker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageablePerson
{    
    [SerializeField] private EnemyTargetDetector _targetDetector;
    [SerializeField] private EnemyAttackRangeScanner _attackRangeScanner;
    
    private EnemyMover _mover;    
    private EnemyAnimationController _animator;
    private EnemyAttacker _attacker;
    private Rigidbody2D _rigibody;
    private Player _target;
    private Transform _targetTransform;    

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();        
        _animator = GetComponent<EnemyAnimationController>();
        _attacker = GetComponent<EnemyAttacker>();
        _rigibody = GetComponent<Rigidbody2D>();        
        Health = MaxHealth;        
    }

    private void OnEnable()
    {
        _targetDetector.Detected += OnTargetDetected;
        _targetDetector.Lost += OnTargetLost;
        _attacker.Attacked += AnimateAttack;
    }

    private void OnDisable()
    {
        _targetDetector.Detected -= OnTargetDetected;
        _targetDetector.Lost -= OnTargetLost;
        _attacker.Attacked -= AnimateAttack;
    }

    private void Update()
    {
        if (IsDead == false)
        {
            if (_target)
            {                
                if (_attackRangeScanner.IsAttackEnable)
                {
                    if (_attacker.IsAttacking == false && _target.Health > 0)
                        _attacker.Attack(_target);
                }
                else if (_attacker.IsAttacking == false)
                {
                    _mover.FollowTarget(_targetTransform);
                }
            }
            else
            {
                _mover.Patrol();
            }

            _animator.UpdateMove(_mover.GetRunningStatus());
        }
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

    private void OnTargetDetected(Player target)
    {
        _target = target;
        _targetTransform = target.GetComponent<Transform>();
    }

    private void OnTargetLost()
    {
        _target = null;
        _attacker.EndAttack();
    }

    private void AnimateAttack()
    {
        if (IsDead == false)
            _animator.Attack();
    }
}
