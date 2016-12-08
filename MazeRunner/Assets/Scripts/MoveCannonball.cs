using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MoveCannonball : MonoBehaviour {

    public Vector3 vel = Vector3.zero;
    
    float maxLifetime = 1.5f;
    float lifeTimer = 0.0f;

    //public AudioClip hitSound;
    private Clips clipsScript; // holds audio clips
    //private AudioSource source;
	
    void Start()
    {
        clipsScript = GameObject.Find("SoundManager").GetComponent<Clips>();
        //source = GameObject.Find("SoundManager").GetComponent<AudioSource>();
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
        //source.clip = clipsScript.collisionSound;
        AudioSource.PlayClipAtPoint(clipsScript.collisionSound, gameObject.transform.position, 0.2f);


        // destroy
        //print("cannonball collision");
        //print(gameObject.name);
        //print(collision.gameObject.name);
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
