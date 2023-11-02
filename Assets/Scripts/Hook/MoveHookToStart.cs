using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHookToStart : MoveToNewStart
{
    public override void Start()
    {
        endPosition = new Vector3(0, 10f, 0);
        timeDelay = 9f;
    }
}
