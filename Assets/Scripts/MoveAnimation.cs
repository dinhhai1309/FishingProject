using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    private Vector3 targetPosition;
    private Vector2 minBound;
    private Vector2 maxBound;

    void Start()
    {
        minBound = new Vector3(-9.5f, 0.15f, 1f);
        maxBound = new Vector3(9.8f, -9.5f, 1f);
        SetNewRandomTarget();
    }

    void Update()
    {
        // Di chuyển của con cá
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Kiểm tra nếu con cá gần đến điểm đích, thay đổi điểm đích
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewRandomTarget();
        }

        // Kiểm tra nếu con cá ra khỏi giới hạn, đảo hướng di chuyển
        if (transform.position.x < minBound.x || transform.position.x > maxBound.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            SetNewRandomTarget();
        }
    }

    private void SetNewRandomTarget()
    {
        float randomX = Random.Range(-4.0f, 4.0f);
        float randomY = Random.Range(-1.0f, 1.0f);

        // Đảo hướng scale
        if (randomX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // Đảo hướng hướng di chuyển
        targetPosition = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);
    }
}
