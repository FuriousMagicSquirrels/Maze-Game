using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class FaceUpdate1 : MonoBehaviour
{
	public AnimationClip[] animations;

	Animator anim;

	public float delayWeight;
	public string text;
	//public bool imgEnabled = false;
	
	int caseSwitch = 0;
	bool allowDialogue = true;
	private AnimatorStateInfo currentState;
	private AnimatorStateInfo previousState;
    bool blackOut = false;
	AudioSource bgm1;
	AudioSource bgm2;
	
	VignetteAndChromaticAberration script;	
	Fading fadeScript;

	void Start ()
	{
		var aSources = GetComponents<AudioSource> ();
		bgm1 = aSources[0];
		bgm2 = aSources[1];
		bgm1.Play();
		
		fadeScript = GetComponent<Fading>();
		//Debug.Log(script);
		GameObject player = GameObject.Find ("Camera");
		script = player.GetComponent<VignetteAndChromaticAberration>();
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;
		Actions();
	}
	
	void OnGUI () {
		/*if (GUILayout.Button("Skip") && caseSwitch < 20) {
			caseSwitch = 20;
			Actions();
			script.intensity = 1.0f;
			bgm1.Stop();
			bgm2.Stop();
		}*/
	}

	/*void OnGUI ()
	{
		foreach (var animation in animations) {
			if (GUILayout.Button (animation.name)) {
				anim.CrossFade (animation.name, 0);
				Debug.Log(animation.name);
			}
		}
	}*/

	float current = 0;


	void Update ()
	{
		//text = "Unity: \n Reading from script!";
		if((Input.GetButton("Fire1") || Input.GetButton("Submit")) && allowDialogue)	// left Ctlr
		{	
			caseSwitch++;
			Actions();
			StartCoroutine(ChangeDialogue());
		}
		if (anim.GetBool ("Next")) {
			currentState = anim.GetCurrentAnimatorStateInfo (0);
			if (previousState.nameHash != currentState.nameHash) {
				anim.SetBool ("Next", false);
				previousState = currentState;				
			}
		}
		
		if (blackOut) {
			if (script.intensity > 0) {
				script.intensity -= Time.deltaTime * 0.2f;
			} else {
				script.intensity = 0.0f;
				blackOut = false;
			}
		}
		
		/*if (anim.GetBool ("Next")) {
			anim.SetBool("Next", false);
		}*/

		/*if (Input.GetMouseButton (0)) {
			current = 1;
		} else {
			current = Mathf.Lerp (current, 0, delayWeight);
			Debug.Log(current);
		}*/
		anim.SetLayerWeight (1, 1);
	}
	
	IEnumerator ChangeDialogue() {
		allowDialogue = false;
		yield return new WaitForSeconds(1.0f);
		allowDialogue = true;
	}
	
	IEnumerator EndIntro() {
		float fadeTime = fadeScript.BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		//Load Level
		SceneManager.LoadScene("menu");
	}
	
	void Actions() {
		switch (caseSwitch) {
			case 0:
				text = "Okay, I’ve completed all your mazes. Now where is your end of the deal?";
				break;
			case 1:
				text = "Calamity: \nAlright, alright. I did say I was an entity of my word. I will now return you to your oh-so-dearly beloved, perfectly healthy friend. But do come back and play again~";
				break;
			case 2:
				text = "Doubt it...";
				break;
			case 3:
				text ="Sarah: \nHey sleepy head! How long are you going to just lay there?";
				anim.CrossFade ("smile1@unitychan", 0);
				blackOut = true;
				bgm1.Stop();
				bgm2.Play();
				break;
			case 4:
				text = "Oh, hey.";
				break;
			case 5:
				text = "Sarah: \nIs something wrong?";
				anim.CrossFade ("smile2@unitychan", 0);
				anim.SetBool("Next", true);
				break;
			case 6:
				text = "Nah, it's nothing";
				break;
			default:
				break;
		}
	}
}
