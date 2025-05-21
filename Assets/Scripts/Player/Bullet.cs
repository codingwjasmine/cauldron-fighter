using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health health = collision.GetComponent<Health>();
            health.TakeDamage(10); // Call the TakeDamage method on the HealthController component
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
