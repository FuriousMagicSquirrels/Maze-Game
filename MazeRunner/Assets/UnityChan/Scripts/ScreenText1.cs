using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenText1 : MonoBehaviour {
	Text text;
	FaceUpdate1 script;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		GameObject player = GameObject.Find ("unitychan");
        script = player.GetComponent<FaceUpdate1>();	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = script.text;
	}
}
