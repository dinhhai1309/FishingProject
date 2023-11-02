using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundItemManager : MonoBehaviour
{
    public virtual void onSoundItem(AudioSource itemSound)
    {
        itemSound.Play();
    }
}
