using UnityEngine;
using System.Collections;
using System;

public class SoundPlayer : MonoBehaviour
{

    public static SoundPlayer Instance;

    //Sound sources
    public AudioClip shot1;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundManager!");
        }
        Instance = this;
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position, 10f);
    }

    public void playShot1()
    {
        MakeSound(shot1);
    }
}
