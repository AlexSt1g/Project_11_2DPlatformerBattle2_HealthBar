using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);
    private const KeyCode Jump = KeyCode.Space;
    private const KeyCode Attack = KeyCode.KeypadEnter;

    private bool _isJump;
    private bool _isAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
        
        if (Input.GetKeyDown(Jump))
            _isJump = true;

        if (Input.GetKeyDown(Attack))
            _isAttack = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;        
        return localValue;
    }
}
