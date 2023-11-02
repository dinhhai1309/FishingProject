using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDropHook : TimeManager
{
    public MoveHook moveHook;
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
        return elapsedTime >= 6;
    }

    // Override phương thức thực hiện hành động
    public override void PerformAction()
    {
        moveHook.Move();
    }
}
