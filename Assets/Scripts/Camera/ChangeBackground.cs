using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : TimeManager
{
    GameObject backgroundWin;
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
    }

    void Awake()
    {
        backgroundWin = GameObject.Find("BackgroundWin");
    }
    // Override phương thức kiểm tra điều kiện
    public override bool CheckElapsedTime()
    {
        return elapsedTime >= 10;
    }

    // Override phương thức thực hiện hành động
    public override void PerformAction()
    {
        ChangeBackgroundWin();
    }
    public void ChangeBackgroundWin()
    {
        // Thực hiện logic khi backgroundEnable là true
        Renderer renderer = backgroundWin.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = 3;
        }

    }

}

