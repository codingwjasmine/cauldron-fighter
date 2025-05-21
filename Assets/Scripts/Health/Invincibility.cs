using UnityEngine;
using System.Collections;
public class Invincibility : MonoBehaviour
{
    private Health _health; // Reference to the HealthController component

    private void Awake()
    {
        _health = GetComponent<Health>(); // Get the HealthController component
        
    }

    public void StartInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration)); // Start the invincibility coroutine
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        _health.IsInvincible = true; // Set the player to invincible
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        _health.IsInvincible = false; // Set the player back to normal
    }
}
