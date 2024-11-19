using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();             
    }    

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        TurnInDirection(direction);

        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);        
    }

    private void TurnInDirection(float direction)
    {
        float TurnLeftYAxisDegreese = 180;
        float TurnRightYAxisDegreese = 0;

        if (direction < 0)
            transform.rotation = Quaternion.Euler(0, TurnLeftYAxisDegreese, 0);
        else
            transform.rotation = Quaternion.Euler(0, TurnRightYAxisDegreese, 0);
    }
}
