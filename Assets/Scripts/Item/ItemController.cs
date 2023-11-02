using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private MoveHook moveHook;
    private SoundManager soundManager;
    public TextManager textManager;
    public SoundItemManager soundItemManager;
    public AudioSource soundItem;
    public Text itemText;
    public void Start()
    {
        // Tìm và lấy tham chiếu đến HookController
        moveHook = FindObjectOfType<MoveHook>();
        soundManager = FindObjectOfType<SoundManager>();

        // Thêm đối tượng Item này vào danh sách trong HookController

    }

    private void OnMouseDown()
    {
        if (moveHook != null)
        {
            GameManager.Instance.SetTabItem(true);
            moveHook.SetItemSound(soundItem);
            moveHook.SetItemText(itemText);
            // Gắn item làm con của hook và di chuyển hook đến item
            moveHook.MoveToItemAndAttach(this.gameObject);

        }
    }
}
