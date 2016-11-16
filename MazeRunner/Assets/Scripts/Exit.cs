
﻿//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3



using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {


	void Update () {

        if (Input.GetKey("escape"))

            SceneManager.LoadScene("menu");


            SceneManager.LoadScene("menu");


    }
}
