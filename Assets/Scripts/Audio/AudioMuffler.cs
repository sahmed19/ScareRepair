using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class AudioMuffler : MonoBehaviour
{

    public Transform player;

    AudioLowPassFilter filter;

    bool obstacle = false;

    public LayerMask maskObstacles;

    private void Start()
    {
        filter = GetComponent<AudioLowPassFilter>();
    }
    private void Update()
    {
        obstacle = true;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, player.position - transform.position);
        if(Physics.Raycast(ray, out hit, maskObstacles.value))
        {
            if(hit.collider.CompareTag("Player"))
            {
                obstacle = false;
            }
            Debug.Log(obstacle);
        }

        filter.cutoffFrequency = Mathf.Lerp(filter.cutoffFrequency, obstacle ? 3500 : 20000, 5.0f * Time.deltaTime);
    }
}
