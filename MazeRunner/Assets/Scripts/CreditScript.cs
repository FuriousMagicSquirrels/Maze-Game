//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3



using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour {

	Text text;
	float speed = 30.0f;
	Vector3 originalPos;
	string[] credits = {"Environment Designer: Jennifer Ma",
						"Player Animation: Annie Matin & Brandon Chiem",
						"AI Logic: Trung Nguyen",
						"User Interface: Chao Wang",
						"Character Models downloaded from mixamo.com",
						"Character Animations downloaded from mixamo.com & http://files.unity3d.com/will/MecanimTute.zip",
						"Credits background from http://i.imgur.com/nGRDDfJ.jpg" };
	int creditCounter = 0;
	bool flag = true;

	void Start () {
		text = GetComponent <Text> ();
		originalPos = text.transform.position;
		
		text.text = credits[creditCounter];
		text.CrossFadeAlpha(0.0f, 0.05f, false);
		text.CrossFadeAlpha(1.0f, 0.5f, false);
	}
	
	// Update is called once per frame
	void Update () {
		text.transform.Translate(Vector3.up * Time.deltaTime * speed);
		//print(Screen.height);
		if (text.transform.position.y > .6*Screen.height && flag)
		{
			text.CrossFadeAlpha(0.0f, 0.5f, false);
			flag = false;
			creditCounter++;
			if(creditCounter < credits.Length) {
				StartCoroutine (ChangeText());
			}
		}
	}
	
	IEnumerator ChangeText() {
		yield return new WaitForSeconds(2.0f);
		//Change Text, reset position and flag
		text.text = credits[creditCounter];
		text.transform.position = originalPos;
		flag = true;
		//Fade in Text
		text.CrossFadeAlpha(0.0f, 0.05f, false);
		text.CrossFadeAlpha(1.0f, 0.5f, false);
	}
}
