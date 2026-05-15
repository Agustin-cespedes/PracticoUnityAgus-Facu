using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        Vector2 dir = Vector2.zero;
        if (kb.wKey.isPressed) dir.y += 1f;
        if (kb.sKey.isPressed) dir.y -= 1f;
        if (kb.aKey.isPressed) dir.x -= 1f;
        if (kb.dKey.isPressed) dir.x += 1f;

        Move(dir.normalized);
    }

    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = direction * speed;
    }
}
