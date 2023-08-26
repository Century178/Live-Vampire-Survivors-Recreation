using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector3[] spawnPoint;
    [SerializeField] private Transform player;

    private float spawnTime;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRateMin;
    [SerializeField] private float rampUp;

    private void Update()
    {
        transform.position = player.position;

        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            spawnTime = spawnRate;
            if (spawnRate >= spawnRateMin) spawnRate -= rampUp;

            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(enemy, transform.position + spawnPoint[i], Quaternion.identity);
            }
        }
    }
}
