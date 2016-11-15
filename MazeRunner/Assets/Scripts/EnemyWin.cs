using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyWin : MonoBehaviour {

void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Enemy1" || col.gameObject.name == "Enemy2" || col.gameObject.name == "Enemy3") {
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
	}
}
