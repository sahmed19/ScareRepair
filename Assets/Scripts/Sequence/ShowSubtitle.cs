using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowSubtitle : MonoBehaviour
{

    public TextMeshProUGUI subtitle;

    public void ShowSub(string sub)
    {
        StartCoroutine(ShowSubCoroutine(sub));
    }

    IEnumerator ShowSubCoroutine(string sub)
    {

        yield return new WaitForSeconds(3.0f);
        subtitle.text = sub;

        float t = 5.0f;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            subtitle.color = new Color(1f, 1f, 1f, .5f * Mathf.Clamp01(t));
            yield return null;
        }

    }

}
