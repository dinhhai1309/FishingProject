using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWater : TimeManager
{
    public AudioSource soundUnderWater;
    public AudioSource soundBlueSea;
    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
    }

    public override bool CheckElapsedTime()
    {
        // Thay đổi giá trị ngưỡng kiểm tra thành 10
        return elapsedTime >= 5;
    }

    // Override phương thức thực hiện hành động
    public override void PerformAction()
    {
        soundBlueSea.Stop();
        soundUnderWater.Play();
    }
}
