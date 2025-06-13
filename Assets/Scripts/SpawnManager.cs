using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //Float to select array of objects
    public GameObject[] animalPrefabs;
    private float spawnPosx = 13;
    private float spawnPosz = 20;
    private float startDelay = 1f;
    private float spawnInterval = 0.5f;
    private int score;
    //[SerializeField] private Button start;
    public bool isGameOver;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button start;
    [SerializeField] private Button restart;
    [SerializeField] private Button reset;
    [SerializeField] private Button quit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameOver = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomAnimal()
    {
        //Random range (array) using total length of items not the actual range
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosx, spawnPosx), 0, spawnPosz);
        //Instantiate
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    public void StartGame()
    {
        isGameOver = false;
        title.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        reset.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        SpawnAnimals();
        score = 0;
        
        

    }
    public void AddScore(int points)
    {
        score += points; 
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameOver = true;
        restart.gameObject.SetActive(true);
        reset.gameObject.SetActive(false);
        CancelInvoke("SpawnRandomAnimal");
        gameOver.gameObject.SetActive(true);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SpawnAnimals()
    {
        
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        
    }
   public void QuitGame()
    {
  
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}    
