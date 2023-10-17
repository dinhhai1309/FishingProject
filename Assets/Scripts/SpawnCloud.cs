using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud: MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 2f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
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
        Instantiate(cloud, transform.position, transform.rotation);
        timer = 0;
    }

}
