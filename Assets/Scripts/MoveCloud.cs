using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud: MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float deadClound = -12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
