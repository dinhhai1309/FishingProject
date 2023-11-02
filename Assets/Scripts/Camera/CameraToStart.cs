using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToStart : MoveToNewStart
{
    public override void Start()
    {
        endPosition = new Vector3(0, 0f, -10f);
        StartCoroutine(delayTenSecond(10));
    }
    public override void Update()
    {
        StartCoroutine(checkItem());       
    }

    public IEnumerator delayTenSecond(int timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);

    }

    public override void Move()
    {
        StartCoroutine(MoveCameraSmoothly(endPosition));
        StartCoroutine(delayFiveSecond(4));
    }

    public IEnumerator delayFiveSecond(int timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        GameManager.Instance.SetComplete(true);
    }
}

