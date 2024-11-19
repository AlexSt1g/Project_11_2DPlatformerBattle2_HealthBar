public class HealingSourse : ActionButton
{
    protected override void HandleButtonClick()
    {
        Target.Heal(Value);
    }
}
