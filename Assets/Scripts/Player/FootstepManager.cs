using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{

    public FootstepAudioPack currentAudioPack;

    public AudioSource source;

    bool leftFootForward;
    int index;
    public void TakeFootstep()
    {

        source.pitch = Random.Range(.8f, 1.2f);

        leftFootForward = !leftFootForward;

        index = Random.Range(0, 2);

        if(leftFootForward)
        {
            source.panStereo = -.5f;
            source.clip = currentAudioPack.leftFootsteps[index];
        } else
        {
            source.panStereo = .5f;
            source.clip = currentAudioPack.rightFootsteps[index];
        }

        source.Play();

    }

}
