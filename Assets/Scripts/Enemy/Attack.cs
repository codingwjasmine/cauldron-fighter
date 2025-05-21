using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
        private float _damageAmount;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<Health>();

            healthController.TakeDamage(_damageAmount); // Call the TakeDamage method on the HealthController component
        }
    }
}