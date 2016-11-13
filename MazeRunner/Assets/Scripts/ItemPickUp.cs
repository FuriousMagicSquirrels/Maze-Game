using UnityEngine;
using System.Collections;

public class ItemPickUp : MonoBehaviour {

    private int numSpeedPots = 3;
    private int numStunBombs = 3;
    private float throwSpeed = 15.0f;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("R pressed");
            if (numStunBombs > 0)
            {
                UseStunBomb();
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            print("T pressed");
            if (numSpeedPots > 0)
            {
                UseSpeedPot();
            }
        }



    }

    void OnCollisionEnter(Collision collision)
    {
        print("collision");
        GameObject obj = collision.gameObject;
        if (obj.name == "SpeedPotion(Clone)")
        {
            print("speedpotion");
            numSpeedPots++;
            // play a sound
            Destroy(obj);

        }
        else if (obj.name == "StunBombItem(Clone)")
        {
            numStunBombs++;
            // play a sound
            Destroy(obj);
        }
    }

    void UseStunBomb()
    {
        numStunBombs--;

        // play a sound

        // throw stun bomb
        Vector3 startPos = transform.position + new Vector3(0.5f, 1.5f, 0.0f); // offset from player (put 0.5 in Z instead of X if u reset player's y-rot to 0)
        StunBomb sb = Instantiate(Resources.Load("StunBomb", typeof(StunBomb)), startPos, Quaternion.identity) as StunBomb;
        sb.vel = transform.forward * throwSpeed;
    }

    void UseSpeedPot()
    {
        print("setting anim speed");
        anim.speed = 5.0f; // doesnt work...
    }
}
