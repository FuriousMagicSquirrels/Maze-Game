using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageEnabler : MonoBehaviour {
	Image img;
	FaceUpdate script;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		GameObject player = GameObject.Find ("unitychan");
        script = player.GetComponent<FaceUpdate>();	
	}
	
	// Update is called once per frame
	void Update () {
		img.enabled = script.imgEnabled;
	}
}
