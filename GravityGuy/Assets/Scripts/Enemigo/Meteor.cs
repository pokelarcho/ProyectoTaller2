using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;

    public float INICIO;
    public float FINAL;

    private float spawnTimer = 0f;
    public float spawnInterval = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }

    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(INICIO, FINAL), transform.position.y);
        GameObject obj = Instantiate(enemies[0], spawnPos, Quaternion.identity);
        obj.transform.parent = transform;
    }

}
