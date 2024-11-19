using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Died += Die;
    }

    private void OnDisable()
    {
        _player.Died -= Die;
    }

    public void UpdateMove(bool isRunning, bool isGround)
    {        
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, isRunning);
        _animator.SetBool(PlayerAnimatorData.Params.IsGround, isGround);
    }    

    public void Jump()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Jump);
    }

    public void Attack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Attack);
    }    

    public void TakeHit()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.TakeHit);
    }

    public void SetLifeStatus(bool isDead)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsDead, isDead);
    }

    private void Die()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Die);
    }
}
