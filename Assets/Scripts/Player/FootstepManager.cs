using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{

    FootstepAudioPack currentAudioPack;

    AudioSource source;

    bool leftFootForward;
    int index;
    public void TakeFootstep()
    {
        leftFootForward = !leftFootForward;

        if(leftFootForward)
        {
            index++;
            index = index % 3;
        }

        if(leftFootForward)
        {
            source.clip = currentAudioPack.leftFootsteps[index];
        } else if(leftFootForward)
        {
            source.clip = currentAudioPack.rightFootsteps[index];
        }

        source.Play();

    }

}
