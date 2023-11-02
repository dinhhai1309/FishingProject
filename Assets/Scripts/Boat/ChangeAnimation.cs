using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ChangeAnimation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsComplete() == true)
        {
            ChangeAnimationState();
        }
    }

    public void ChangeAnimationState()
    {
        SkeletonAnimation skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationName = "Ending";
    }
}
