using UnityEngine;
using System.Collections;

public class CannonballManager : MonoBehaviour {

    // instantiate cannonballs every x seconds, with their own move script
    float intervalSec = 1.0f;
    float timer = 0.0f;

    public static int numCannonballs = 9;
    //GameObject cannonballHolder;
    Vector3[] cbPositions = new Vector3[numCannonballs];
    //float[] cb = new Vector3[numCannonballs];
    Vector3[] cbVels = new Vector3[numCannonballs];

    float speed = 7.0f;

    //Cannonball cbType;

    // Use this for initialization
    void Start () {
        //cannonballHolder = GameObject.Find("Cannonballs");

        // get positions of all cannonballGhost objects
        for (int i = 0; i < numCannonballs; i++)
        {
            // get pos
            string objName = "CannonballGhost (" + i + ")";
            GameObject obj = GameObject.Find("Cannonballs/"+objName);
            Vector3 pos = obj.transform.position;
            //print("pos:" + pos);
            
            // set pos
            cbPositions[i] = pos;

            // get velocity
            CannonballDirection cbDirScript = obj.GetComponent<CannonballDirection>();

            // set vel
            //print("cbDirScript.vel: " + cbDirScript.vel);
            cbVels[i] = cbDirScript.vel;

            // inactivate ghosts
            obj.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
        if (timer >= intervalSec)
        {
            // instantiate cannonballs
            for (int i = 0; i < numCannonballs; i++)
            {
                Vector3 pos = cbPositions[i];
                Vector3 vel = cbVels[i];

                // instantiate at ghost obj's position
                GameObject cb = (GameObject) Instantiate(Resources.Load("Cannonball"), pos, Quaternion.identity);

                // get script moveCannonball
                MoveCannonball moveCbScript = cb.GetComponent<MoveCannonball>();

                // set script's speed
                //print("vel: " + vel);
                //print("speed:" + speed);
                //Vector3 newVel = vel * speed;
                //print("newVel:" + newVel);
                moveCbScript.vel = vel * speed;
            }


            // reset timer 
            timer = 0.0f;
        }
        else
        {
            // update timer
            timer += Time.deltaTime;
        }
	}
}
