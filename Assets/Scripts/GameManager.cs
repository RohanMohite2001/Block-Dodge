using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;
    public float maxPos;
    public GameObject blockPrefab;
    public float spawnRate;
    bool gameStarted = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameStarted == false)
        {
            StartSpawning();
            gameStarted = true;
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
    }
}
