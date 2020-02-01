using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{

    public LayerMask interactableLayer;

    public InteracterUI interacterUI;

    float progress;

    private void Update()
    {

        Interactable closestInteractable = GetInteractablesInVicinity();

        if(closestInteractable != null)
        {
            ExamineInteractable(closestInteractable);
        } else
        {
            progress = 0f;
            interacterUI.SetPrompt("");
            interacterUI.SetSlider(0f);
        }

    }

    private Interactable GetInteractablesInVicinity()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + Vector3.forward, 2.0f, interactableLayer.value);

        Interactable closestInteractable = null;
        float highestDot = -2.0f;
        foreach(Collider col in colliders)
        {
            Interactable interactable = col.GetComponent<Interactable>();
            float dot = Vector3.Dot(transform.forward, (transform.position - col.transform.position).normalized);
            
            
            if(interactable != null && highestDot < dot)
            {
                closestInteractable = interactable;
                highestDot = dot;
            }
        }

        return closestInteractable;
        
    }

    private void ExamineInteractable(Interactable interactable)
    {
        if(Input.GetButton("Interact"))
        {
            progress += Time.deltaTime;
        } else
        {
            progress -= Time.deltaTime * 3.0f;
        }

        progress = Mathf.Clamp(progress, 0f, 20f);

        interacterUI.SetPrompt(interactable.Prompt());
        interacterUI.SetSlider(progress / interactable.Time());

        if (progress > interactable.Time())
        {
            interactable.Interact();
        }

    }

}
