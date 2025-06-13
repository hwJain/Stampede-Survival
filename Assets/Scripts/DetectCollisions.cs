using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private SpawnManager spawnManager;
    [SerializeField] private int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnManager == null)
        {
            spawnManager = Object.FindFirstObjectByType<SpawnManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Enemy") && other.CompareTag("Projectile"))
        {
            spawnManager.AddScore(points);  // Use the enemy's point value
            Destroy(other.gameObject);      // Destroy the projectile
            Destroy(gameObject);            // Destroy the enemy
                                            //when collisions happen, objects are destroyed

        }
    }
}
