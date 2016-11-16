//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3


using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Vector2 offset = new Vector2(Time.time * speed , 0);
		Vector2 offset = new Vector2(0, -Time.time * speed);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
