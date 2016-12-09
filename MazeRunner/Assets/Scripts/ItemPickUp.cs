using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemPickUp : MonoBehaviour {

    private int numSpeedPots = 3;
    private int numStunBombs = 3;
    private float throwSpeed = 15.0f;

    GameObject textObj;
    Text textComp;

    Animator anim;
    public AudioClip pick;
    public AudioClip throwb;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        // for UI for stun bomb count
        textObj = GameObject.Find("Text");
        textComp = textObj.GetComponent<Text>();
        updateBombCountUI();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("R pressed");
            if (numStunBombs > 0)
            {
                
                GetComponent<AudioSource>().clip = throwb;
                GetComponent<AudioSource>().Play();
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
            Debug.Log("pickup");
            GetComponent<AudioSource>().clip = pick;
            GetComponent<AudioSource>().Play();
            numStunBombs++;
            updateBombCountUI();

            // play a sound


            Destroy(obj);
        }
    }

    void UseStunBomb()
    {
        numStunBombs--;
        updateBombCountUI();

        // play a sound

        // throw stun bomb
        Vector3 startPos = transform.position + new Vector3(0.5f, 1.5f, 0.5f); // offset from player (put 0.5 in Z instead of X if u reset player's y-rot to 0)
        StunBomb sb = Instantiate(Resources.Load("StunBomb", typeof(StunBomb)), startPos, Quaternion.identity) as StunBomb;
        sb.vel = transform.forward * throwSpeed;
    }

    void UseSpeedPot()
    {
        print("setting anim speed");
        anim.speed = 5.0f; // doesnt work...
    }

    void updateBombCountUI()
    {
        textComp.text = numStunBombs.ToString();
    }
}
