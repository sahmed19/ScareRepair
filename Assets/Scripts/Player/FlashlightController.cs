using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    Vector3 eulerAnglesOld;
    Vector3 eulerAnglesDelt;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation,
            Quaternion.Euler(
            new Vector3(-Input.GetAxis("MouseY"), Input.GetAxis("MouseX"), 0f) * 2f),
            Time.deltaTime * 3.0f);
    }

}
