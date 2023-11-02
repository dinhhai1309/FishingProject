using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeManager : MonoBehaviour, ITimeManagerment
{
    protected float elapsedTime = 0.0f;
    protected bool ShouldContinueCounting;

    public virtual void Init()
    {
        elapsedTime = 0.0f;
        ShouldContinueCounting = true;
        StartCountingTime();
    }

    public void StartCountingTime()
    {
        StartCoroutine(IncreaseElapsedTime());
    }

    public virtual IEnumerator IncreaseElapsedTime()
    {
        while (ShouldContinueCounting)
        {
            yield return new WaitForSeconds(1.0f);
            elapsedTime += 1.0f;
            Debug.Log(elapsedTime);
            if (CheckElapsedTime())
            {
                PerformAction();
                break;
            }
        }
        ShouldContinueCounting = false;
    }

    public abstract bool CheckElapsedTime();

    public abstract void PerformAction();
}
