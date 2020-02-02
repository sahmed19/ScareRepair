using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, Interactable
{
    public Light light;

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

    public float TimeToComplete()
    {
        return 0.6f;
    }

    public bool Enabled()
    {
        return true;
    }

}
