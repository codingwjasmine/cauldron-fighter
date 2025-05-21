using UnityEngine;

public class HealthPack : MonoBehaviour
{   
    [SerializeField]
        private float _healthAmount; // Amount of health to restore
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the collided object is the player
        {
            Debug.Log("Player collided with health pack"); // Log message for debugging
        
            var health = collision.GetComponentInParent<Health>();
            if (health != null)
            {
                health.AddHealth(_healthAmount); // Restore health to the player
                Destroy(gameObject); // Destroy the health pack after use
            }
            else
            {
                Debug.LogError("Health component not found on player"); // Log error if Health component is not found
            }
        }
    
    
    
    }
}
