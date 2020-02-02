﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
    public Transform doorHinge;
    public bool open;

    public AnimationCurve doorSwingCurve;

    public AudioSource source;

    public AudioClip openDoor;
    public AudioClip closeDoor;

    bool inProgress = false;

    public bool Enabled()
    {
        return !inProgress;
    }

    public void Interact()
    {
        OpenCloseDoor();
    }

    

    public string Prompt()
    {
        return (open ? "Open Door" : "Close Door");
    }

    public float TimeToComplete()
    {
        return .6f;
    }

    public void OpenCloseDoor()
    {
        StopCoroutine(DoorCoroutine());
        open = !open;
        source.clip = (open ? closeDoor : openDoor);
        source.Play();
        StartCoroutine(DoorCoroutine());
    }

    IEnumerator DoorCoroutine()
    {
        inProgress = true;
        float time = 0f;
        while(time < 1.5f)
        {
            time += Time.deltaTime;

            float t = time / 1.5f;

            doorHinge.localEulerAngles =
                Vector3.forward * Mathf.LerpUnclamped(0f, -90f, doorSwingCurve.Evaluate(
                    (open ? (1f-t) : t)
                    ));

            yield return null;

        }
        inProgress = false;
    }

}
