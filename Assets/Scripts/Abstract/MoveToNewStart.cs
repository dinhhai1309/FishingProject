using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveToNewStart : MoveByTime
{
    public float timeDelay;
    public override void Start()
    {
    }

    public virtual void Update()
    {
        StartCoroutine( checkItem());
    }

    public IEnumerator checkItem()
    {
        GameObject itemsObject = GameObject.Find("Items");
        if (itemsObject != null)
        {
            // Kiểm tra childCount của "Items" để xem có đứa con nào không
            if (itemsObject.transform.childCount == 0)
            {
                yield return new WaitForSeconds(timeDelay);
                Move();
            }
        }
    }

    public override void Move()
    {
        StartCoroutine(MoveCameraSmoothly(endPosition));
    }
}
