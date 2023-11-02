using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 5f;
    private float timer = 0;

    void Start()
    {
        spawnCloud();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
        }
    }

    void spawnCloud()
    {
        Instantiate(cloud, transform.parent.position, transform.parent.rotation);
        timer = 0;
    }
}
