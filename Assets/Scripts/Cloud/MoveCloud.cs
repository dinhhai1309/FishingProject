using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float moveSpeed = 3f;
    public void Update()
    {
        Move();
    }
    public void Move()
    {
        // Hiện thực phương thức Move.
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }
}
