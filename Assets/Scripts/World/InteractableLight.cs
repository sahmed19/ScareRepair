using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, Interactable
{
    public Light light;
    public float speed;

    public void Interact()
    {
        light.enabled = !light.enabled;
    }

    public string Prompt()
    {
        if(light.enabled)
        {
            return "Turn Off Light";
        }

        return "Turn On Light";
    }

    public float Time()
    {
        return 0.7f;
    }

    public bool Enabled()
    {
        return true;
    }

}
