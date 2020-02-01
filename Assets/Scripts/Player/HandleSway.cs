using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSway : MonoBehaviour
{
    public float recoverySpeed = 8.0f;
    public float swayStrength = 4.0f;
    Vector3 restingPosition;

    float locomotiveForce;

    Vector3 lastPosParent;
    Vector3 deltParent;

    private void Start()
    {
        restingPosition = transform.localPosition;
    }
    private void Update()
    {
        
        transform.localPosition = Vector3.Lerp(transform.localPosition, restingPosition, recoverySpeed * Time.deltaTime);
        transform.localPosition += Vector3.up * Mathf.Sin(Time.time * 7f) * locomotiveForce * .2f * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(Vector3.right * Mathf.Cos(.2f + Time.time * 7f) * locomotiveForce);
    }

    private void LateUpdate()
    {
        deltParent = transform.parent.localPosition - lastPosParent;
        transform.localPosition += deltParent * -.1f;
        lastPosParent = transform.parent.localPosition;
    }

    public void AddMouseMotion(Vector2 m)
    {
        transform.localPosition += new Vector3(-m.x, m.y, 0f) * .2f * swayStrength * Time.deltaTime;
    }

    public void SetLocomotion(float m)
    {
        locomotiveForce = m;
    }

}
