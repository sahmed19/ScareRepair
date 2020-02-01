using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorHinge;
    public bool open;

    public AnimationCurve doorSwingCurve;
    public void OpenCloseDoor()
    {
        open = !open;
        StartCoroutine(DoorCoroutine());
    }

    IEnumerator DoorCoroutine()
    {
        float t = 0f;
        while(t < 1.0f)
        {
            t += Time.deltaTime;

            doorHinge.localEulerAngles =
                Vector3.forward * Mathf.LerpUnclamped(0f, -90f, doorSwingCurve.Evaluate(
                    (open ? (1f-t) : t)
                    ));

            yield return null;

        }
    }

}
