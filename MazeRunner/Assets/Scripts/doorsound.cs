using UnityEngine;
using System.Collections;

public class doorsound : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Player") || (other.gameObject.name == "Enemy1") || (other.gameObject.name == "Enemy2") || (other.gameObject.name == "Enemy3"))
        {
            Debug.Log("doorsound");
            GetComponent<AudioSource>().Play();
        }
    }
}