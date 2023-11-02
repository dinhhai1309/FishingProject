using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }
    private bool complete = false;
    private bool tabItem = false;

    public void Update()
    {

    }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo rằng đối tượng GameManager không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject); // Nếu đã tồn tại một đối tượng GameManager khác, hủy bản thân đối tượng này
        }
    }

    public bool IsComplete()
    {
        return complete;
    }

    public void SetComplete(bool value)
    {
        complete = value;
    }

    public bool IsTabItem()
    {
        return tabItem;
    }

    public void SetTabItem(bool value)
    {
        tabItem = value;
    }
}
