using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{

    public FirstPersonController fpcontroller;

    public AudioSource source;


    public void StartEQ()
    {
        StartCoroutine(EQ());
    }
    IEnumerator EQ()
    {
        for (int i = 0; i < 200; i++)
        {
            if (i < 100)
            {
                source.volume = 1f;
                fpcontroller.ShakeScreen(1f);
                yield return new WaitForSeconds(.01f);
            } else
            {
                float x = (200 - i)/100f;
                source.volume = x;
                fpcontroller.ShakeScreen(Mathf.Clamp01(x-.4f));
                yield return new WaitForSeconds(.01f);
            }
        }
        source.volume = 0f;

    }

}
