using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

public string nextLevelName;
public bool winEnable = false;
public bool loseEnable = false;

void Update() {
	if (winEnable) {
		if (Input.GetButton("Fire1") || Input.GetButton("Submit")) {
			SceneManager.LoadScene(nextLevelName);
		}
	} else if (loseEnable) {
		if (Input.GetButton("Fire1") || Input.GetButton("Submit")) {
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
	}
}

void OnCollisionEnter(Collision col) {
		if (loseEnable || winEnable) {
			return;
		}
		if (col.gameObject.name == "Enemy1" || col.gameObject.name == "Enemy2" || col.gameObject.name == "Enemy3") {
			loseEnable = true;
		}
		else if(col.gameObject.name == "Player") {
			winEnable = true;
		}
	}
}
