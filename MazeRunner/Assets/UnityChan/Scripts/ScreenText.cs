using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour {
	Text text;
	FaceUpdate script;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		GameObject player = GameObject.Find ("unitychan");
        script = player.GetComponent<FaceUpdate>();	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = script.text;
	}
}
