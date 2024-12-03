using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerTargetDetector))]
[RequireComponent(typeof(PlayerContactDetector))]
[RequireComponent(typeof(PlayerSpawner))]
[RequireComponent(typeof(Collider2D))]
public class Player : DamageablePerson
{
    private PlayerMover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;
    private PlayerAnimationController _animator;
    private PlayerAttacker _attacker;
    private PlayerTargetDetector _targetDetector;
    private PlayerContactDetector _contactDetector;
    private Enemy _target;

    public event Action<int> CoinCountChanged;

    public int ÑoinCount { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<PlayerAnimationController>();
        _attacker = GetComponent<PlayerAttacker>();
        _targetDetector = GetComponent<PlayerTargetDetector>();
        _contactDetector = GetComponent<PlayerContactDetector>();
        Health = MaxHealth;
    }

    private void OnEnable()
    {
        _contactDetector.CoinPickedUp += AddCoin;
        _contactDetector.HealingPotionPickedUp += Heal;
        _contactDetector.OnDeathZoneEnter += TakeHit;
        _inputReader.JumpKeyPressed += OnJump;
        _inputReader.AttackKeyPressed += OnAttack;
    }

    private void OnDisable()
    {
        _contactDetector.CoinPickedUp -= AddCoin;
        _contactDetector.HealingPotionPickedUp -= Heal;
        _contactDetector.OnDeathZoneEnter -= TakeHit;
        _inputReader.JumpKeyPressed -= OnJump;
        _inputReader.AttackKeyPressed -= OnAttack;
    }

    private void FixedUpdate()
    {
        if (IsDead == false)        
            if (_inputReader.Direction != 0)
                _mover.Move(_inputReader.Direction);
    }

    private void Update()
    {
        if (IsDead == false)
            _animator.UpdateMove(_inputReader.Direction != 0, _groundDetector.IsGround);
    }

    public override void TakeHit(int damageValue)
    {
        _animator.TakeHit();

        base.TakeHit(damageValue);
    }

    public override void Revive()
    {
        base.Revive();

        _animator.SetLifeStatus(IsDead);
    }

    protected override void Die()
    {
        base.Die();

        _animator.SetLifeStatus(IsDead);
    }

    private void AddCoin()
    {
        ÑoinCount++;

        CoinCountChanged?.Invoke(ÑoinCount);
    }

    private void OnJump()
    {
        if (IsDead == false)
        {
            if (_groundDetector.IsGround)
            {
                _mover.Jump();
                _animator.Jump();
            }
        }
    }

    private void OnAttack()
    {
        if (IsDead == false)
        {
            if (_targetDetector.TryGetTarget(_attacker.AttackRange, out _target))
                _attacker.Attack(_target);

            _animator.Attack();
        }
    }
}
