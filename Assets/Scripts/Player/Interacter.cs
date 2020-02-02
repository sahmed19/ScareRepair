using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{

    public LayerMask interactableLayer;

    public InteracterUI interacterUI;

    float progress;

    bool interactInputResetter = false;

    public HammerSwing swing;
    private void Update()
    {
        if (Input.GetButtonUp("Interact"))
        {
            interactInputResetter = false;
        }

        Interactable closestInteractable = GetInteractablesInVicinity();

        if(closestInteractable != null)
        {
            interacterUI.SetButtonVisibility(true);
            ExamineInteractable(closestInteractable);
        } else
        {


            progress = 0f;
            interacterUI.SetPrompt("");
            interacterUI.SetSlider(0f);
            interacterUI.SetButtonVisibility(false);
            swing.SetMagnitude(0f);
        }

    }

    private Interactable GetInteractablesInVicinity()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.0f, interactableLayer.value);

        Interactable closestInteractable = null;
        float highestDot = .95f;
        foreach(Collider col in colliders)
        {
            Interactable interactable = col.GetComponent<Interactable>();
            float dot = Vector3.Dot(transform.forward, (col.transform.position - transform.position).normalized);
            
            if(interactable != null && interactable.Enabled() && dot > highestDot)
            {
                closestInteractable = interactable;
                highestDot = dot;
            }
        }

        return closestInteractable;
        
    }

    private void ExamineInteractable(Interactable interactable)
    {
        if (Input.GetButton("Interact") && !interactInputResetter)
        {
            progress += Time.deltaTime;
            swing.SetMagnitude(1f);
        } else
        {
            progress -= Time.deltaTime * 3.0f;
            swing.SetMagnitude(0f);
        }

        progress = Mathf.Clamp(progress, 0f, 20f);

        interacterUI.SetPrompt(interactable.Prompt());
        interacterUI.SetSlider(progress / interactable.TimeToComplete());

        if (progress > interactable.TimeToComplete())
        {
            interacterUI.Pulse();
            interactable.Interact();
            progress = 0f;
            interactInputResetter = true;
        }

    }

}
