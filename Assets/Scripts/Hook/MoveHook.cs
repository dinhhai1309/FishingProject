using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveHook : MoveByTime
{
    protected bool allowRun = true; // cho phesp di chuyen tiep
    protected float timeDelay;
    protected int delayPosition = 2;  // vị trí delay
    protected int successfulGrips = 0; // biến đếm vị trí
    protected int currentIndex = 0;
    protected Vector3 currentPosition; // vị trí cập nhật sau mỗi lần chạy
    protected Vector3 startPositionHook; // vị trí cập nhật sau mỗi lần chạy

    public List<Vector3> position = new List<Vector3>();
    [SerializeField] public AudioSource soundTopic;
    [SerializeField] public AudioSource underWaterSound;
    [SerializeField] public AudioSource soundHook;

    public GameManager GameManager;
    public SoundManager soundManager;
    public PositionManager positionManager;
    private GameObject currentItem;
    public TextManager textManager;
    public SoundItemManager soundItemManager;
    public AudioSource itemSound;
    public Text itemText;

    public override void Start()
    {
        startPosition = new Vector3(2.5f, 4f, 0);
        endPosition = new Vector3(0, -8.2f, 0);
    }

    public override void Move()
    {
        StartCoroutine(MoveCameraSmoothly(endPosition));
        GetSoundManager();
    }

    public void Update()
    {
        if (GameManager.Instance.IsTabItem())
        {
            currentIndex = PositionChecker.CheckPosition(ref allowRun, itemSound, soundHook, soundItemManager, soundManager, position, transform.parent, currentItem, currentIndex, 0.1f);
            checkAllow();
        }
    }

    public void checkAllow()
    {
        if (allowRun)
        {
            MoveHooktoNewPosition(position[currentIndex], 3f);
        }
        else
        {
            textManager.textItemEnableTrue(itemText);
            StartCoroutine(DelayPosition(1f));
        }
    }

    public void GetSoundManager()
    {
        soundManager = gameObject.AddComponent<SoundManager>();
        StartCoroutine(soundManager.CheckMoveCoroutineAndPlaySound(soundTopic, underWaterSound));
    }


    public void MoveToItemAndAttach(GameObject item)
    {
        GetTextManager();
        GetSoundItem();
        soundManager.stopSoundTopic(soundTopic);
        currentItem = item;
        Vector3 touchPosition = item.transform.position;
        position = positionManager.CalculatePositions(touchPosition); // Lưu trữ danh sách vị trí từ CalculatePositions
    }

    public void GetTextManager()
    {
        textManager = gameObject.AddComponent<TextManager>();
    }

    public void GetSoundItem()
    {
        soundItemManager = gameObject.AddComponent<SoundItemManager>();
    }

    private void MoveHooktoNewPosition(Vector3 currentPos, float speed)
    {
        Vector3 dirt = Vector3.Normalize(currentPos - transform.parent.position);
        transform.parent.position += dirt * Time.deltaTime * speed;
    }

    IEnumerator DelayPosition(float time)
    {
        yield return new WaitForSeconds(time);
        allowRun = true;
        textManager.textItemEnableFalse(itemText);
    }

    public virtual void SetItemText(Text textItem)
    {
        itemText = textItem;
    }

    public virtual void SetItemSound(AudioSource soundItem)
    {
        itemSound = soundItem;
    }
}

