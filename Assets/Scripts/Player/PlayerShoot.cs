using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
        private GameObject _bulletPrefab; 

    [SerializeField]
        private float _bulletSpeed; 

    [SerializeField]
        private float _timeBetweenShots; // Time between shots
    
    private float _lastFireTime;
    private bool _fireSingle;
    private bool _fireContinuously; // Flag to check if the fire button is pressed
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
   
    private void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireContinuously || _fireSingle) // Check if the fire button is pressed or if it's a single fire
        {
            float timeSinceLastFire = Time.time - _lastFireTime; // Calculate the time since the last fire
            
            if (timeSinceLastFire >= _timeBetweenShots) // Check if enough time has passed since the last fire
            {
                FireBullet();

                _lastFireTime = Time.time; // Update the last fire time
                _fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        float offsetDistance = 1.5f;
        Vector3 spawnOffset = (spriteRenderer.flipX ? Vector3.left : Vector3.right) * offsetDistance + Vector3.up * 0.5f; // Calculate the spawn offset based on the sprite's flip state
        Vector3 spawnPosition = transform.position + spawnOffset; // Calculate the spawn position for the bullet

        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity); // Create a new bullet instance
        
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bullet
        rigidbody.linearVelocity = _bulletSpeed * (spriteRenderer.flipX ? Vector2.left : Vector2.right); // Set the bullet's velocity
        
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed; // Check if the fire button is pressed

        if(inputValue.isPressed)
        {
            _fireSingle = true; // Set the fireSingle flag to true when the button is pressed
        }
    }
}
