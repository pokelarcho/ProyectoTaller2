using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;

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
        Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(0.6f, 0.8f, 10f));
        GameObject obj = Instantiate(enemies[0], spawnPos, Quaternion.identity);
        obj.transform.parent = transform;
    }

}
