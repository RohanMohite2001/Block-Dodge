using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Transform spawnPoint;
    public float maxPos;
    public GameObject blockPrefab;
    public float spawnRate;
    bool gameStarted = false;

    public TextMeshProUGUI scoreText;
    int score = 0;

    public TextMeshProUGUI highScoreText;
    int highScore;
    public GameObject tapImage;

    private void Start()
    {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameStarted == false)
        {
            StartSpawning();
            gameStarted = true;
            tapImage.gameObject.SetActive(false);
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    void SpawnBlock()
    {
        Vector2 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxPos, maxPos);
        Instantiate(blockPrefab, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Game");
    }
}
