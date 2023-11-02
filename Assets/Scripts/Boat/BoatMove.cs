using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour,IMove
{
    protected Vector3 startPosition;
    protected Vector3 middleOfScreen;
    protected  float moveDuration = 0.25f;
    protected float startTime;

    private void Start()
    {
        startPosition = transform.parent.position;
        middleOfScreen = new Vector3(0, -2.2f, 0);
    }
    void Update()
    {
        Move();      
    }

    public void Move()
    {
        float journeyLength = Vector3.Distance(startPosition, middleOfScreen);
        float distanceCovered = (Time.time - startTime) / moveDuration;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.parent.position = Vector3.Lerp(startPosition, middleOfScreen, fractionOfJourney);
    }
}
