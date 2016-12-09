using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class FaceUpdate : MonoBehaviour
{
	public AnimationClip[] animations;

	Animator anim;

	public float delayWeight;
	public string text;
	public bool imgEnabled = false;
	
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
		GameObject player = GameObject.Find ("FirstPersonCharacter");
		script = player.GetComponent<VignetteAndChromaticAberration>();
		fadeScript = GetComponent<Fading>();
		//Debug.Log(script);
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;
		Actions();
	}
	
	void OnGUI () {
		if (GUILayout.Button("Skip") && caseSwitch < 20) {
			caseSwitch = 20;
			Actions();
			script.intensity = 1.0f;
			bgm1.Stop();
			bgm2.Stop();
		}
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
			if (script.intensity < .92) {
				script.intensity += Time.deltaTime * 0.5f;
			} else {
				script.intensity = 1.0f;
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
		SceneManager.LoadScene("Level1Remake");
	}
	
	void Actions() {
		switch (caseSwitch) {
			case 0:
				text = "Okay Sarah, why did you drag me all the way to this place. What is this place anyways?";
				anim.CrossFade ("default@unitychan", 0);
				break;
			case 1:
				text = "Sarah: \nI just have something to tell you is all…";
				anim.CrossFade ("conf@unitychan", 0);
				anim.SetBool("Next", true);
				break;
			case 2:
				text = "Okay… and you had to drag me to this creepy place to tell me…?";
				break;
			case 3:
				text = "Sarah: \nYea~";
				anim.CrossFade ("smile1@unitychan", 0);
				anim.SetBool("Next", true);
				break;
			case 4:
				text = "Sarah: \nWell you see, I don’t have long to live… I’ve been sick for a while now, and I’m running out of time…";
				anim.CrossFade ("angry1@unitychan", 0);
				anim.SetBool("Next", true);
				break;
			case 5:
				text = "Oh…";
				break;	
			case 6:
				text = "Sarah: \nI just wanted to let you know, being my best friend and all.";
				anim.CrossFade ("smile2@unitychan", 0);
				anim.SetBool("Next", true);
				break;
			case 7:
				text = "Ah… That’s… this is a bit much to take in… I …. I….";
				break;
		    case 8:
				text = "Sarah \nWait, what’s going on? Are you okay? Hey!";
				anim.CrossFade ("sap@unitychan", 0);
				anim.SetBool("Next", true);
				blackOut = true;
				bgm1.Stop();
				bgm2.Play();
				break;
			case 9: 
				text = "???: \nWell hello there.";
				break;
			case 10:
				text = "Who is this?";
				break;
			case 11:
				text = "???: \nYou can call me Calamity. Or just Clammy for short, but only my high school friends really call me that…";
				break;
			case 12:
				text = "What’s going on?";
				break;
			case 13: 
				text = "Calamity: \nWell you see, it seems like you’re in a great deal of distress right now, which makes you a perfect contestant for my brand new game!";
				break;
			case 14:
				text = "...wtf.";
				break;
			case 15:
				text = "Calamity: \nOh come on, don’t be that way. If you manage to win, I can even save your friend.";
				break;
			case 16:
				text = "Really? What do I need to do?";
				break;
			case 17:
				text = "Calamity: \nSimple. Make your way to the campfire in the maze and you win! But you’ve got to be the first one to the campfire.";
				break;
			case 18:
				text = "So there are others as well?";
				break;
			case 19:
				text = "Calamity: \nBut of course! What fun is a game without other players? ";
				break;
			case 20:
				text = "Calamity: \nLook, I like you so I’ll even help you out. Use WASD to move, Spacebar to jump, Left Shift to walk, C to crouch, and I’ll even throw in some stun bombs for you to stun opponents. Hit R to throw those bad boys.";
				imgEnabled = true;
				break;
			case 21:
				text = "You’d better hold your end of the bargain.";
				break;
			case 22:
				text = "Oh you betcha. I’m an entity of my word. Best of luck~";
				imgEnabled = false;
				break;
			case 23:
				StartCoroutine(EndIntro());
				break;
			default:
				break;
		}
	}
}
