using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class BoatAndCatBehavior : MonoBehaviour
{
    [SerializeField] GameObject _boatAndCat;
    [SerializeField] GameManager GameManager;
    public float moveDuration = 0.25f;
    private float startTime;
    protected float elapsedTime = 0f; // Thời gian đã trôi qua
    private Vector3 startPosition;
    private Vector3 middleOfScreen;
    protected bool isMoving = false;
    private bool hasPlayedSoundCong= false; 
    private bool hasPlayedSoundHu = false; 

    public AudioSource soundCong;
    public AudioSource soundHurrah;
    void Start()
    {
        startPosition = transform.position;
        middleOfScreen = new Vector3(0, -2.2f, 0);
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        float journeyLength = Vector3.Distance(startPosition, middleOfScreen);
        float distanceCovered = (Time.time - startTime) / moveDuration;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, middleOfScreen, fractionOfJourney);
        if (GameManager.Instance.IsWinBoatAndCat())
        {
            SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
            skeletonAnimation.AnimationName = "Ending";
        }
        if (GameManager.Instance.IsWinBoatAndCat())
        {
            elapsedTime = 0.0f; // Đặt lại thời gian đã trôi qua
            StartMove();
        }
    }

    private void StartMove()
    {
        StartCoroutine(IncreaseElapsedTime());
    }
    protected IEnumerator IncreaseElapsedTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            elapsedTime += 1.0f;
            if(elapsedTime == 1f)
            {
                StartCoroutine(onSoundCongratulation());
                
            }
            else if(elapsedTime == 7f)
            {
                StartCoroutine(onSoundHurrah());
            }
            else if (elapsedTime >= 13f)
            {
                StartCoroutine(MoveBoatCatToStart( moveDuration));
                soundHurrah.Stop();
            }
        }
    }
    protected IEnumerator MoveBoatCatToStart(float duration)
    {
        startPosition = new Vector3(12f, -2.2f, 0);
        Vector3 currentPosition = transform.position;
        float journeyLength = Vector3.Distance(currentPosition, startPosition);
        // Khởi tạo thời gian bắt đầu di chuyển
        float startTime = Time.time;

        while (true)
        {
            // Tính toán thời gian đã trôi qua kể từ khi bắt đầu di chuyển
            float timeSinceStarted = Time.time - startTime;
            duration = 2f;
            // Tính toán phần trăm đã di chuyển
            float fractionOfJourney = Mathf.Clamp01(timeSinceStarted / duration);
            // Di chuyển đối tượng dựa trên phần trăm đã di chuyển
            transform.position = Vector3.Lerp(currentPosition, startPosition, fractionOfJourney);
            yield return null;
        }

    }
    protected IEnumerator onSoundCongratulation()
    {
        onSoundCon();
        yield return null;
    }

    private void onSoundCon()
    {
        if (!hasPlayedSoundCong)
        {
            soundCong.Play();
            hasPlayedSoundCong = true;
        }
    }

    protected IEnumerator onSoundHurrah()
    {
        onSoundHu();
        yield return null;
    }

    private void onSoundHu()
    {
        if (!hasPlayedSoundHu)
        {
            soundCong.Stop();
            soundHurrah.Play();
            hasPlayedSoundHu = true;
        }
    }
}
