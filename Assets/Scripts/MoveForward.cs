using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    private SpawnManager spawnManager;
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
        if(!spawnManager.isGameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
     
        
    }
}
