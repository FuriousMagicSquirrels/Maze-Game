﻿using UnityEngine;
using System.Collections;

public class StunPlayer : MonoBehaviour {

    Animator anim;
    Rigidbody playerRigidbody;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cannonball(Clone)")
        {
            anim.SetTrigger("Stun");
        }
    }
}
