using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperViewer : MonoBehaviour
{

    public AnimationCurve drawCurve;

    float drawn = 0f;

    public Texture2D[] paperTextures;

    public MeshRenderer paperRenderer;

    int index = 0;

    private void Update()
    {

        if (Input.GetButton("ShowPaper"))
        {
            drawn += Time.deltaTime * 3.0f;
        } else
        {
            drawn -= Time.deltaTime * 3.0f;
        }

        drawn = Mathf.Clamp01(drawn);

        transform.localEulerAngles = Vector3.right * 90f * (1f-drawCurve.Evaluate(drawn));

    }

    public void NextPaper()
    {
        index++;
        paperRenderer.material.SetTexture("_MainTex", paperTextures[index]);
    }

}
