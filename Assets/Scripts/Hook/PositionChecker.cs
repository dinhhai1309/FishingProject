using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionChecker
{
    public static int CheckPosition(ref bool allowRun, AudioSource itemSound,AudioSource soundHook,SoundItemManager soundItemManager,SoundManager soundManager, List<Vector3> positions, Transform transform, GameObject currentItem, int currentIndex, float threshold)
    {
        if (currentIndex >= positions.Count)
        {
            // Nếu currentIndex vượt qua số lượng vị trí, xóa danh sách và đặt lại currentIndex
            positions.Clear();
            currentIndex = 0;
            return currentIndex;
        }
        if (Vector3.Distance(positions[currentIndex], transform.position) <= threshold)
        {
            switch (currentIndex)
            {
                case 0:
                    soundManager.onSoundHook(soundHook);
                    break;
                case 1:
                    GameObject Hook = GameObject.Find("Hook");
                    currentItem.transform.SetParent(Hook.transform);
                    soundManager.stopSoundHook(soundHook);
                    break;
                case 2:
                    allowRun = false;
                    soundItemManager.onSoundItem(itemSound);
                    break;
                case 3:
                    currentItem.SetActive(false);
                    break;
                case 4:
                    break;
                default:
                    // Xử lý trường hợp currentIndex không nằm trong danh sách trên
                    break;
            }
            currentIndex++; // Tăng currentIndex
        }
        return currentIndex; // Trả về currentIndex mới
    }
}
