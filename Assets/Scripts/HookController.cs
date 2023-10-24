using System.Collections;
using UnityEngine;
using Spine.Unity;
using System.Collections.Generic; // Thêm dòng này để sử dụng List<>
using UnityEngine.UI;


public class HookController : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    protected Vector3 startMovePosition;
    public Vector3 endMovePosition;
    protected float moveDuration = 2f;
    protected float elapsedTime = 0f;
    private bool isMoving = false;
    public bool hasPlayedSound = false;
    public bool clickEnabledItem = true;
    private GameObject currentItem;
    public bool allowRun = true; // cho phesp di chuyen tiep
    public bool run;
    public float timeDelay;
    public int delayPosition = 2;  // vị trí delay
    public int successfulGrips = 0; // biến đếm vị trí
    public int currentIndex = 0;
    public Vector3 currentPosition; // vị trí cập nhật sau mỗi lần chạy
    public Text itemText;
    public AudioSource soundHook;
    public AudioSource soundTopic;
    public AudioSource soundUnderWater;
    private AudioSource itemSound;
    // Danh sách chứa tất cả các đối tượng ItemController
    private List<ItemController> itemControllers = new List<ItemController>();
    public List<Vector3> position = new List<Vector3>();
    public void Start()
    {
        startMovePosition = transform.position;
        endMovePosition = new Vector3(0, -9f, 0);
        StartCoroutine(IncreaseElapsedTime());
    }
    public void Update()
    {
        if (GameManager.Instance.IsTabItem())
        {
            CheckPosition();
            if (allowRun)
            {
                if (clickEnabledItem)
                {
                    MoveHook(position[currentIndex], 3f);
                }
            }
            if (!allowRun)
            {
                itemText.enabled = true; 
                StartCoroutine(DelayPosition(0.5f));
            }
        }
        
    }
    public void MoveToItemAndAttach(GameObject item)
    {
        //soundTopic.Stop();
        currentItem = item;
        Vector3 touchPosition = item.transform.position;
        CalculatePosotion(touchPosition);
    }

    public void CalculatePosotion(Vector3 touchPosition)
    {
        Vector3 startPosition = transform.position;
        Debug.Log(startPosition);
        var position0 = new Vector3(touchPosition.x, startPosition.y, 0);
        position.Add(position0);
        var position1 = touchPosition;
        position.Add(position1);
        var position2 = new Vector3(touchPosition.x, startPosition.y, 0);
        position.Add(position2);
        var position3 = new Vector3(touchPosition.x, -4f, 0);
        position.Add(position3);
        var position4 = startPosition;
        position.Add(position4);
        currentPosition = position[0];
        currentIndex = 0;
    }
    private void CheckPosition()
    {
        if (soundTopic != null)
        {
            soundTopic.mute = true; // Tắt tiếng cho AudioSource
        }
        

        if (Vector3.Distance(position[currentIndex], transform.position) <= 0.1f)
        {
            switch (currentIndex)
            {
                case 0:
                    soundHook.Play();
                    break;
                case 1:
                    GameObject Hook = GameObject.Find("Hook");
                    currentItem.transform.SetParent(Hook.transform);
                    soundHook.Stop();
                    break;
                case 2:
                    allowRun = false;
                    itemSound.Play();
                    break;
                case 3:
                    currentItem.SetActive(false);
                    break;
                case 4:
                    successfulGrips++;
                    Debug.Log("successfulGrips" + successfulGrips);
                    position.Clear();
                    // Đặt lại currentIndex để bắt đầu lại
                    currentIndex = 0;
                    break;
                default:
                    // Xử lý trường hợp currentIndex không nằm trong danh sách trên
                    break;
            }
            if (successfulGrips == 4 && CountRemainingItems() == 0)
            {
                isMoving = true;
                StartCoroutine(DelayPosition(2));
                StartCoroutine(MoveHookToStart(startMovePosition, moveDuration));
            }
            if (currentIndex <= position.Count - 1)
            {
                currentIndex++;
                currentPosition = position[currentIndex];
            }
            else
            {
                GameManager.Instance.SetTabItem(false);         
            }
        }
    }


    private void MoveHook(Vector3 currentPos, float speed)
    {
        clickEnabledItem = false;
        Vector3 dirt = Vector3.Normalize(currentPos - transform.position);
        transform.position += dirt * Time.deltaTime * speed;
        Debug.Log(transform.position +"dfsgd");
        clickEnabledItem = true;
    }

    IEnumerator DelayPosition(float time)
    {
        yield return new WaitForSeconds(time);
        allowRun = true;
        itemText.enabled = false;
    }

    // Coroutine để tăng elapsedTime sau mỗi giây
    protected IEnumerator IncreaseElapsedTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            elapsedTime += 1.0f;

            if (elapsedTime == 5f)
            {
                StartCoroutine(MoveHookSmoothly(endMovePosition, moveDuration));
            }
        }
    }

    protected IEnumerator MoveHookSmoothly(Vector3 targetPosition, float duration)
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
        sound();
    }

    private void sound()
    {
        if (!hasPlayedSound) // Kiểm tra xem sound() đã được gọi hay chưa
        {
            soundUnderWater.Stop();
            StartCoroutine(LoopSoundTopic());
            hasPlayedSound = true; // Đặt biến kiểm tra thành true khi đã gọi sound()
        }
    }

    private IEnumerator LoopSoundTopic()
    {
        while (true)
        {
            if (!soundTopic.isPlaying)
            {
                soundTopic.Play();
            }
            yield return new WaitForSeconds(5.0f);
            soundTopic.Stop();
        }
    }

    protected IEnumerator MoveHookToStart(Vector3 targetPosition, float duration)
    {
        float startTime = Time.time;
        Vector3 currentPosition = new Vector3(0, -9f, 0);

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }
        isMoving = false;
        GameManager.Instance.SetComplete(true);
    }

    private int CountRemainingItems()
    {
        // Đếm số item còn lại trong scene
        ItemController[] items = FindObjectsOfType<ItemController>();
        return items.Length;
    }

    // Phương thức để thêm một đối tượng ItemController vào danh sách
    public void AddItem(ItemController item)
    {
        itemControllers.Add(item);
    }

    // Phương thức để nhận tham chiếu đến soundItem từ ItemController
    public void SetItemSound(AudioSource sound)
    {
        itemSound = sound;
    }
    public void SetItemText(Text textComponent)
    {
        itemText = textComponent;
    }
}
