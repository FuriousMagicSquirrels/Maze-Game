using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialoguePanelEnabler : MonoBehaviour {
	Image img;
	LevelChanger script;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
        Transform fire = GameObject.Find ("Campfire").transform;
		script = fire.Find("CampfireCollider").GetComponent<LevelChanger>();
	}
	
	// Update is called once per frame
	void Update () {
		img.enabled = script.winEnable || script.loseEnable;
	}
}
