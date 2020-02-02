using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fade;
    float fac = 0;

    public void StartFading()
    {
        fading = true;
    }

    bool fading = false;
    private void Update()
    {
        if(fading)
        {
            fac += Time.deltaTime;
            Color c = Color.black;
            c.a = fac / 10.0f;
            fade.color = c;
            if(fac > 15.0f)
            {
                Application.Quit();
            }
        }
    }

}
