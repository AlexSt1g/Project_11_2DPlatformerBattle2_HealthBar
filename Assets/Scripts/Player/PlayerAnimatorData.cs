using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        public static readonly int IsGround = Animator.StringToHash(nameof(IsGround));
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Die = Animator.StringToHash(nameof(Die));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int TakeHit = Animator.StringToHash(nameof(TakeHit));
        public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    }
}
