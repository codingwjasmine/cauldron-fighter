using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{   
    [SerializeField]
        private float delay; // Delay before destroying the enemy game object
    [SerializeField]
        private HealthSpawner _healthSpawner; // Reference to the HealthSpawner component
    
    public static int TotalKills { get; set; } // Static property to keep track of total kills
    
    private void OnEnable()
    {
        var health = GetComponent<Health>(); // Get the Health component attached to the enemy
        if (health != null)
        {
            health.OnDied.AddListener(HandleDeath); 
        }
    }
    private void HandleDeath()
    {
        TotalKills++; // Increment the enemy death count
        Debug.Log("Enemy Death Count: " + TotalKills); // Log the enemy death count for debugging

        if (TotalKills % 5 == 0) // Check if the death count is a multiple of 5
        {
            Debug.Log("spawn health pack"); // Log message for debuggin

        _healthSpawner.SpawnHealthPack(transform.position); // Spawn health item on enemy death
        
        }
        // Destroy the enemy game object
        Destroy(gameObject, delay);
    }

}