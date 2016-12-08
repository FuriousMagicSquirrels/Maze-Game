using UnityEngine;
using System.Collections;

public class MoveCannonball : MonoBehaviour {

    public Vector3 vel = Vector3.zero;
    
    float maxLifetime = 1.5f;
    float lifeTimer = 0.0f;

    //public AudioClip hitSound;
    private AudioSource source;
	
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

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

        // collision explosion sound
        source.Play();


        // destroy
        print("cannonball collision");
        print(gameObject.name);
        print(collision.gameObject.name);
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
