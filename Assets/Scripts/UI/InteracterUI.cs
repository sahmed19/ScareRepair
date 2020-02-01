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

    AudioSource chargingSource;


    private void Start()
    {
        chargingSource = GetComponent<AudioSource>();
    }

    public void SetPrompt(string text)
    {
        prompt.text = text;
    }

    public void SetSlider(float value)
    {
        slider.fillAmount = value;
        chargingSource.volume = value * .1f;
        chargingSource.pitch = Mathf.Lerp(.7f, 1f, value);
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
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * (curve.Evaluate(t));
            yield return null;
        }

    }

}
