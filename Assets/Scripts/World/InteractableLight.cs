using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, Interactable
{
    public Light[] lights;

    public MeshRenderer meshRenderer;

    public Color emissionColor;

    public void Interact()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
        meshRenderer.materials[1].SetColor("_EmissionColor", emissionColor * (lights[0].enabled ? 1f : 0f));
    }

    public string Prompt()
    {
        if(lights[0].enabled)
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
