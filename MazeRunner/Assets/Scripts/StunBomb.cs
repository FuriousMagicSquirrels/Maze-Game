using UnityEngine;
using System.Collections;

public class StunBomb : MonoBehaviour
{

    public Vector3 vel;
    float maxLifetime = 1.0f;
    float lifetime = 0;

    GameObject player;
    //PlayerScript script;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //script = player.GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // move projectile based on dir and speed
        this.transform.position += vel * Time.deltaTime;
        Vector3 newPos = this.transform.position;

        if (lifetime >= maxLifetime)
        {
            if (this.gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            lifetime += Time.deltaTime;
        }
    }


    //void OnTriggerEnter(Collider other)
    void OnCollisionEnter(Collision collision)
    {
        print("sb collision");
        if (collision.gameObject.tag == "Enemy") // set tag...
        {

            //script.PlayHitSound();
            //script.DecreaseHP(atkDmg);
            // script.stunAI();

            print("hit AI");

            // play the AI's Stun animation
            collision.gameObject.GetComponent<Animator>().SetTrigger("Stun");

            if (this.gameObject != null)
            {
                Destroy(gameObject);
            }

        }
    }
}
