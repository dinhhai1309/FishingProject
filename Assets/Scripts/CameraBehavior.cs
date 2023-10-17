using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    protected Vector3 startPosition; // Vị trí ban đầu của camera
    protected Vector3 endPosition; // Vị trí thứ hai của camera
    protected float moveDuration = 1.5f; // Thời gian di chuyển, đã được đặt thành 0.05 giây
    protected float elapsedTime = 0.0f; // Thời gian đã trôi qua
    protected bool clickEnabled = false;
    protected bool isMoving = false; // Biến đánh dấu xem camera có đang di chuyển hay không
    public bool shouldContinueCounting = true; // Biến kiểm tra nên đếm tiếp hay không

    [SerializeField] GameManager GameManager;
    public AudioSource soundUnderWater;
    public AudioSource soundBlueSea;

    protected void Start()
    {
        soundBlueSea.Play();
        startPosition = transform.position;
        endPosition = new Vector3(0, -11f, -10f);
        StartCoroutine(IncreaseElapsedTime());
    }

    protected void Update()
    {
        if (GameManager.Instance.IsComplete())
        {
            isMoving = true;
            elapsedTime = 0.0f; // Đặt lại thời gian đã trôi qua
            StartCoroutine(MoveCameraToStart( moveDuration));
        }
    }

    // Coroutine để di chuyển camera từ từ
    private IEnumerator MoveCameraSmoothly(Vector3 targetPosition, float duration)
    {
        float startTime = Time.time;
        Vector3 currentPosition = transform.position;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }

        isMoving = false;
        // Thay đổi Order in Layer của object BackgroundWin
        GameObject backgroundWin = GameObject.Find("BackgroundWin");
        if (backgroundWin != null)
        {
            Renderer renderer = backgroundWin.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sortingOrder = 3;
            }
        }
    }

    // Coroutine để tăng elapsedTime sau mỗi giây
    protected IEnumerator IncreaseElapsedTime()
    {
        while (shouldContinueCounting)
        {
            yield return new WaitForSeconds(1.0f);
            elapsedTime += 1.0f;
            if (elapsedTime >= 5f)
            {
                soundBlueSea.Stop();
                soundUnderWater.Play();
                StartCoroutine(MoveCameraSmoothly(endPosition, moveDuration));
                clickEnabled = true;
                shouldContinueCounting = false; // Dừng việc đếm khi đạt 5 giây
            }
            
        }
    }

    protected IEnumerator MoveCameraToStart(float duration)
    {
        yield return new WaitForSeconds(1.0f);
        elapsedTime += 1.0f;
        if (elapsedTime >= 2f)
        {
            duration = 1f;
            float startTime = Time.time;
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = startPosition;

            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
                yield return null;
            }

            // Khi di chuyển hoàn thành, đặt lại biến isMoving
            isMoving = false;
            GameManager.Instance.SetWinBoatAndCat(true);
        }
        
    }
}