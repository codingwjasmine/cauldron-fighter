using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    private float _speed = 1f; 
    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection; 
    private SpriteRenderer _spriteRenderer;
    private Camera _mainCamera;
    private float _changeDirectionCooldown;
    


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mainCamera = Camera.main; 
        _targetDirection = transform.right;


        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTargetDirection();
        FlipEnemy(); // Flip the enemy sprite based on movement direction
        SetVelocity(); // Set velocity based on target direction
        ClampToScreenBounds(); // Clamp the enemy position to screen bounds
    }

    private void UpdateTargetDirection()
    {   
        HandleRandomMovement();
        HandlePlayerTargeting(); 
    }

    private void HandleRandomMovement()
    {
        _changeDirectionCooldown -= Time.deltaTime; 

        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f); // Random angle change
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection; // Rotate the target direction
        
            _changeDirectionCooldown = Random.Range(1f, 5f); // Reset cooldown to a random value between 1 and 3 seconds
        
        }
    }

    private void HandlePlayerTargeting()
    { 
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    private void SetVelocity()
    {

        _rigidbody.linearVelocity = _targetDirection * _speed; // Move in the direction the enemy is facing
    }
    

    private void FlipEnemy()
    {
        if (_targetDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_targetDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void ClampToScreenBounds()
    {
        Vector3 screenPos = transform.position;
        screenPos = _mainCamera.WorldToViewportPoint(screenPos); // Convert world position to viewport position
        screenPos.x = Mathf.Clamp(screenPos.x, 0.05f, 0.95f); // Adjust these values to set the clamping bounds
        screenPos.y = Mathf.Clamp(screenPos.y, 0.05f, 0.95f); // Adjust these values to set the clamping bounds
        transform.position = _mainCamera.ViewportToWorldPoint(screenPos);
    }

}
