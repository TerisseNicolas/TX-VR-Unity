using UnityEngine;
using System.Collections;
using System;

public class SoundPlayer : MonoBehaviour
{

    public static SoundPlayer Instance;

    //Sound sources
    public AudioClip shot1;
    public AudioClip impact1;
    public AudioClip reload1;
    public AudioClip dryFireGun1;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundManager!");
        }
        Instance = this;
        Debug.Log("ok");
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position, 10f);
    }

    //Todo multiple shot sounds (shotgun, pistol, automatic)
    public void playShot1()
    {
        MakeSound(shot1);
    }
    public void playImpact1()
    {
        MakeSound(impact1);
    }
    public void playReload1()
    {
        MakeSound(reload1);
    }
    public void playDry1()
    {
        MakeSound(dryFireGun1);
    }
}
