using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HammerSwing : MonoBehaviour
{
    public AnimationCurve swingAnimation;

    float targetMagnitude;
    float magnitude;

    float t = 0f;

    public UnityEvent onClang;

    bool clangResetter = true;

    public AudioSource source;
    public AudioClip[] hits;
    int hitIndex;



    public void SetMagnitude(float s)
    {
        targetMagnitude = s;
    }

    void Update()
    {
        if(magnitude < .1f)
        {
            t = 0f;
        }

        t += Time.deltaTime;

        if((t % 1.0f) > .6f && clangResetter)
        {
            onClang.Invoke();
            hitIndex = (hitIndex + 1) % hits.Length;
            source.clip = hits[hitIndex];
            source.Play();
            clangResetter = false;
        } else if(t % 1.0f < .1f)
        {
            clangResetter = true;
        }

        magnitude = Mathf.Lerp(magnitude, targetMagnitude, Time.deltaTime * 12.0f);
        transform.localEulerAngles = Vector3.right * Mathf.LerpUnclamped(0f, -50f, swingAnimation.Evaluate(t % 1.0f)) * magnitude;

        transform.localPosition = Vector3.up * .15f +
            Vector3.forward * Mathf.LerpUnclamped(-.1f, .1f, swingAnimation.Evaluate((t - .2f) % 1.0f)) * magnitude;
    }
}
