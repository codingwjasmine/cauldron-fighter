using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
        private GameObject _enemyPrefab;
    [SerializeField]
        private float _minimumSpawnTime;
    [SerializeField]
        private float _maximumSpawnTime;

    private float _timeUntilSpawn;
    private void Start()
    {
        SetTimeUntilSpawn();
    }


    // Update is called once per frame
    private void Update()
    {

        if (EnemyDestroy.TotalKills >= 100) return;
        _timeUntilSpawn -= Time.deltaTime; 

        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy(); // Call the SpawnEnemy method to spawn an enemy
            SetTimeUntilSpawn(); // Reset the spawn time
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0); // Generate a random spawn position
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity); // Instantiate the enemy prefab at the spawn position
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime); // Set a random time until the next spawn
    }
}