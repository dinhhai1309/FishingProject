using System.Collections;
using UnityEngine;
using Spine.Unity;
using System.Collections.Generic; // Thêm dòng này để sử dụng List<>
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public AudioSource soundHook;

    public IEnumerator CheckMoveCoroutineAndPlaySound( AudioSource soundTopic, AudioSource underWaterSound)
    {
        underWaterSound.Stop();
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(LoopSoundTopic(soundTopic));
    }

    public IEnumerator LoopSoundTopic(AudioSource TopicSound)
    {
        while (true)
        {
            TopicSound.Play();
            yield return new WaitForSeconds(5.0f);
        }
    }

    // khi click vào item tắt soundTopic
    public virtual void stopSoundTopic(AudioSource soundTopic)
    {
        if (soundTopic!= null)
        {
            soundTopic.mute = true;
        }
    }

    // PositionChecker truyền tới
    public virtual void onSoundHook(AudioSource soundHook)
    {
        soundHook.Play();
    }

    public virtual void stopSoundHook(AudioSource soundHook)
    {
        soundHook.Stop();
    }


}
