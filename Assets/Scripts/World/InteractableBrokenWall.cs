using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableBrokenWall : InteractableUnityEvent
{
    public UnityEvent onJumpScare;
    bool doneBefore = false;
    public void BeforeComplete()
    {
        if(doneBefore)
        {
            return;
        }

        onJumpScare.Invoke();
        time = 3f;

        doneBefore = true;

    }

}
