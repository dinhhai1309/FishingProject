using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnCloud : ADestroyable
{
    public float deadClound = 12f;
    protected override bool CanDespawn()
    {
        if (transform.position.x > deadClound) return true;
        return false;
    }
}
