public class DamageSourse : ActionButton
{
    protected override void HandleButtonClick()
    {
        Target.TakeHit(Value);
    }
}
