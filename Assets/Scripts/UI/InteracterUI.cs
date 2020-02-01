using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteracterUI : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    public Image slider;
    public Image mouseButton;

    public AnimationCurve curve;

    public void SetPrompt(string text)
    {
        prompt.text = text;
    }

    public void SetSlider(float value)
    {
        slider.fillAmount = value;
    }

    public void SetButtonVisibility(bool b)
    {
        mouseButton.enabled = b;
    }

    public void Pulse()
    {
        StartCoroutine(PulseCoroutine());
    }

    private IEnumerator PulseCoroutine()
    {
        float t = 0f;

        while(t < 1.0f)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * (curve.Evaluate(t));
            yield return null;
        }

    }

}
