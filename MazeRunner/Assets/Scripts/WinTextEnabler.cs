using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinTextEnabler : MonoBehaviour {
	Text text;
	LevelChanger script;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		Transform fire = GameObject.Find ("Campfire").transform;
		script = fire.Find("CampfireCollider").GetComponent<LevelChanger>();
		//Debug.Log("Working");
        //script = fire.GetComponent<EnemyWinLv2>();	
	}
	
	// Update is called once per frame
	void Update () {
		text.enabled = script.winEnable;
		//img.enabled = script.imgEnabled;
	}
}
