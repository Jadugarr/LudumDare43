using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyShower : MonoBehaviour
{
    [SerializeField]
    private GameObject babyPrefab;

    [SerializeField]
    private float minDelay = 0.1f;

    [SerializeField]
    private float maxDelay = 1f;

    [SerializeField]
    private int capacity = 100;

    private float xMin;
    private float xMax;
    private float ySpawn;
    private float nextSpawnTimeStamp;

    // Use this for initialization
    void Start()
    {
        ySpawn = transform.position.y;
        xMin = transform.position.x - transform.localScale.x / 2;
        xMax = transform.position.x + transform.localScale.x / 2;
        nextSpawnTimeStamp = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (capacity == 0)
            return;

        float now = Time.realtimeSinceStartup;
        if (now >= nextSpawnTimeStamp)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), ySpawn);
            Instantiate(babyPrefab);
            babyPrefab.transform.position = spawnPosition;

            capacity--;
            nextSpawnTimeStamp = now + Random.Range(minDelay, maxDelay);
        }

    }
}
