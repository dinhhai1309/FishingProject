using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDropCamera : TimeManager
{
    public CameraMovementManager cameraManager;
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
    }
    // Override phương thức kiểm tra điều kiện
    public override bool CheckElapsedTime()
    {
        return elapsedTime >= 5;
    }

    // Override phương thức thực hiện hành động
    public override void PerformAction()
    {
        cameraManager.Move();  // Hoặc thực hiện hành động khác ở đây
    }
}
