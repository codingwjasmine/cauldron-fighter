using UnityEngine;
using System.Collections.Generic;
public class HealthSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _healthPackPrefabs;

    public void SpawnHealthPack(Vector2 position)
    {
        Debug.Log("Spawning health pack at position: " + position);
        if (_healthPackPrefabs.Count == 0)
        {
            Debug.LogWarning("No health pack prefabs assigned to the spawner.");
            return;
        }
        // Randomly select a health pack prefab from the list
        int randomIndex = Random.Range(0, _healthPackPrefabs.Count);
        GameObject selectedPrefab = _healthPackPrefabs[randomIndex];

        // Instantiate the selected health pack prefab at the specified position
        GameObject healthPack = Instantiate(selectedPrefab, position, Quaternion.identity);
    }
}
