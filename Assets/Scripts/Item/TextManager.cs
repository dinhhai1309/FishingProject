using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    private void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("textItem");
        // Lặp qua từng GameObject và ẩn chúng
        foreach (GameObject item in items)
        {
            Text textComponent = item.GetComponent<Text>();
            textComponent.enabled = false;
        }
    }
    public void textItemEnableTrue(Text itemText)
    {
        itemText.enabled = true;
    }

    public void textItemEnableFalse(Text itemText)
    {
        itemText.enabled = false;
    }

}
