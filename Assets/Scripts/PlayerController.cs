using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 15f;
    //A single range variable created to bound both sides. Treat no as absolute number since +- of variable in if conditions
    public float xRange = 14f;
    //A float(gameobject) to detect the game object we are aiming to throw
    public GameObject projectilePrefab;
    public SpawnManager spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawnManager.isGameOver)
        {
            PlayerMovement();
            ProjectileShoot();
            ScreenBound();
        }

        
       
    }
    void PlayerMovement()
    {
        //Assigning the horizontal an input parameter. Public float to test it 
        horizontalInput = Input.GetAxis("Horizontal");

        //Movement equation
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.CompareTag("Enemy"))
        {
           // spawnManager.isGameOver = true;
        }
    }
    void ScreenBound()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    void ProjectileShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate function
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

}
