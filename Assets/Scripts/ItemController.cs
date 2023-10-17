using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public AudioSource soundItem;
    private HookController hookController;
    [SerializeField] GameManager GameManager;
    public Text textComponent;
    public void Start()
    {
        textComponent.enabled = false; // Ẩn UI Text khi khởi đầu
        // Tìm và lấy tham chiếu đến HookController
        hookController = FindObjectOfType<HookController>();

        // Thêm đối tượng Item này vào danh sách trong HookController
        if (hookController != null)
        {
            hookController.AddItem(this);
        }
    }

    public void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (hookController != null)
        {
            GameManager.Instance.SetTabItem(true);
            // Gắn item làm con của hook và di chuyển hook đến item
            hookController.MoveToItemAndAttach(this.gameObject);

            // Truyền tham chiếu đến soundItem cho HookController
            hookController.SetItemSound(soundItem);
            hookController.SetItemText(textComponent);

        }
    }
}
