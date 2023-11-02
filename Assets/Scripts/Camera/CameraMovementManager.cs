using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MoveByTime
{
    public override void Start()
    {
        endPosition = new Vector3(0, -11f, -10f);
    }

    public override void Move()
    {
        StartCoroutine(MoveCameraSmoothly(endPosition));
    }

}


