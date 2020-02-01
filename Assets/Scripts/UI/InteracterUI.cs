using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteracterUI : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    public Image slider;

    public void SetPrompt(string text)
    {
        prompt.text = text;
    }

    public void SetSlider(float value)
    {
        slider.fillAmount = value;
    }

}
