using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToEnd : MoveByTime
{
    public override void Start()
    {
        endPosition = new Vector3(20f, -2.2f, 0);
    }

    public override void Move()
    {
        StartCoroutine(MoveCameraSmoothly(endPosition));
    }
}
