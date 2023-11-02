using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoat : MonoBehaviour
{
    public AudioSource soundHurrah;
    public AudioSource soundCongratulate;
    protected bool hasPlayedSound = false; // Biến kiểm tra âm thanh đã được chơi hay chưa
    public MoveToEnd moveToEnd;
    // Start is called before the first frame update

    void Update()
    {
        if (!hasPlayedSound && GameManager.Instance.IsComplete())
        {
            soundCongratulate.Play();
            hasPlayedSound = true; // Đánh dấu là âm thanh đã được chơi
            StartCoroutine(onCongratulation());
        }
    }

    IEnumerator onCongratulation()
    {
        yield return new WaitForSeconds(3f);
        soundHurrah.Play();
        StartCoroutine(stopHurrah());
    }

    IEnumerator stopHurrah()
    {
        yield return new WaitForSeconds(3f);
        soundHurrah.Stop();
        moveToEnd.Move();
    }

}
