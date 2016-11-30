using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyWinLv2 : MonoBehaviour {

void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Enemy1" || col.gameObject.name == "Enemy2" || col.gameObject.name == "Enemy3") {
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
		else if(col.gameObject.name == "Player") {
			SceneManager.LoadScene("Level3");
		}
	}
}
