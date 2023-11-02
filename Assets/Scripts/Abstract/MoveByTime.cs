using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveByTime : MonoBehaviour
{
    protected Vector3 startPosition;
    protected Vector3 endPosition;
    public float moveDuration = 2.5f;
    protected bool isMoving = false;

    public abstract void Start();

    public abstract void Move();

    public IEnumerator MoveCameraSmoothly(Vector3 endPosition)
    {
        float startTime = Time.time;
        Vector3 currentPosition = transform.parent.position;
        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            transform.parent.position = Vector3.Lerp(currentPosition, endPosition, t);
            yield return null;
        }
        isMoving = false;
    }
}
