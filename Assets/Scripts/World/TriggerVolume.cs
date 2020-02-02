using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerVolume : MonoBehaviour
{

    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            onTrigger.Invoke();
        }
    }
}
