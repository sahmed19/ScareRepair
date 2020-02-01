using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepardsTone : MonoBehaviour
{
    public AudioSource top;
    public AudioSource middle;
    public AudioSource bottom;

    float t = 0f;

    private void Update()
    {

        t = (t + Time.deltaTime);

        float factor = (t%10f) / 10f;

        top.pitch = Mathf.Lerp(1.25f, 1.0f, factor);
        middle.pitch = Mathf.Lerp(1.0f, .75f, factor);
        bottom.pitch = Mathf.Lerp(.75f, .5f, factor);

        top.volume = factor;
        bottom.volume = 1 - factor;

    }
}
