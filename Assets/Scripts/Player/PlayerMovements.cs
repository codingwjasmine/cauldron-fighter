using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        _animator = GetComponent<Animator>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
        }
    }

    private void FixedUpdate()
    {   
        
        _smoothMovementInput = Vector2.SmoothDamp(
            _smoothMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f ); // Adjust smooth time
        

        _rigidbody.linearVelocity = _smoothMovementInput * 5f; // Adjust speed

        FlipGorilla();

    }

    private void FlipGorilla()
    {
        if (_movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    private void OnMove(InputValue inputvalue)
    {
        _movementInput = inputvalue.Get<Vector2>();
    }
}
