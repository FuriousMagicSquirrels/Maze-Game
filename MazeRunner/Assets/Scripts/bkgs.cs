//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3




using UnityEngine;
using System.Collections;

public class bkgs : MonoBehaviour {
    public float speed = -0.01f;
    private Vector2 offset;
    float pos;
    // Use this for initialization
    void Start ()
    { 
        offset = new Vector2(0,0);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
	}
	
	// Update is called once per frame
	void Update () {
        pos += speed * Time.deltaTime;
        offset = new Vector2(pos, 0f);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}
