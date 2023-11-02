using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloudStart: MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float deadClound = 12f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        if(transform.position.x < deadClound)
        {
            Destroy(gameObject);
        }
    }
}
