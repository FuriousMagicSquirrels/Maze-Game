using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour
{

    //public GameObject leftFootprint;
    //public GameObject rightFootprint;

    public AudioClip[] steps;



    void Start()
    {
    }

    void PlayFootSteps()
    {
        GetComponent<AudioSource>().clip = steps[Random.Range(0, steps.Length)];
        GetComponent<AudioSource>().Play();
    }
}

       

