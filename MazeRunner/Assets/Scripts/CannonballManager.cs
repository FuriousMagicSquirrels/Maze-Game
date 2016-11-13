using UnityEngine;
using System.Collections;

public class CannonballManager : MonoBehaviour {

    // instantiate cannonballs every x seconds, with their own move script
    float intervalSec = 3.0f;
    float timer = 0.0f;
    float speed = 7.0f;

    public int numCannonballs;   
    Vector3[] cbPositions;
    Vector3[] cbVels;    
    
    // Use this for initialization
    void Start () {

        cbPositions = new Vector3[numCannonballs];
        cbVels = new Vector3[numCannonballs];

        // get positions of all cannonballGhost objects
        for (int i = 0; i < numCannonballs; i++)
        {
            // get pos
            string objName = "CannonballGhost (" + i + ")";
            GameObject obj = GameObject.Find("Cannonballs/"+objName);

            // set pos
            Vector3 pos = obj.transform.position;                     
            cbPositions[i] = pos;

            // set velocity
            CannonballDirection cbDirScript = obj.GetComponent<CannonballDirection>();            
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
