using UnityEngine;
using System.Collections;

public class doorsound : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("doorsound");
        GetComponent<AudioSource>().Play();
    }
}