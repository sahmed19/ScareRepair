using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonePlayer : MonoBehaviour
{

    public AudioClip tone;
    public AudioClip toneEnd;

    public AudioSource source;

    bool playing = false;
    float timer = 0f;

    public void StartTone()
    {
        source.clip = tone;
        source.Play();
        playing = true;
    }

    private void Update()
    {
        if(playing)
        {
            timer += Time.deltaTime;
            if (timer > tone.length - 2.0f)
            {
                EndTone();
            }
        } else
        {
            timer = 0f;
        }
    }

    public void EndTone()
    {
        if(!playing)
        {
            return;
        }
        source.clip = toneEnd;
        source.Play();
        playing = false;
    }

}
