﻿//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3




using UnityEngine;
using System.Collections;

public class MoveCannonball : MonoBehaviour {

    public Vector3 vel = Vector3.zero;
    
    float maxLifetime = 1.5f;
    float lifeTimer = 0.0f;
	
	// Update is called once per frame
	void Update () {

        checkLifetime();
        moveCannonball();

    }

    void moveCannonball()
    {
        
        this.transform.position += vel * Time.deltaTime;
    }

    void checkLifetime()
    {
        if (lifeTimer >= maxLifetime)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTimer += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // if player, stun

        // if ai, stun

        // destroy
        //print("collision");
        Destroy(gameObject);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    // if player, stun

    //    // if ai, stun

    //    // destroy
    //    print("triggered");
    //    Destroy(gameObject);
    //}

}
