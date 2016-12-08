using UnityEngine;
using System.Collections;

public class BubbleText : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2f);
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = player.transform.rotation;
	}
}
