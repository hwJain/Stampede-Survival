using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound= 30;
    private float lowBound = -10;
    private SpawnManager spawnManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if(spawnManager == null)
        {
            spawnManager = Object.FindFirstObjectByType<SpawnManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            //Script to destroy gameobject if the condition is met
            Destroy(gameObject);
        }
        else if(transform.position.z < lowBound)
        {
            spawnManager.GameOver();
            //Destroy animals that have passed the screen
            Destroy(gameObject);

        }
    }
}
