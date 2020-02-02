using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesBehavior : MonoBehaviour
{

    float timeOnScreen = 0f;


    Vector3 resting;
    private void OnEnable()
    {
        resting = transform.position;
    }
    private void Update()
    {
        timeOnScreen += Time.deltaTime;

        transform.position = resting + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * Mathf.Clamp01(timeOnScreen/10f);


    }

}
