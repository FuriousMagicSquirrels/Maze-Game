
using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour
{


    LevelChanger script;
    void Awake()
    {

        Transform fire = GameObject.Find("Campfire").transform;
        script = fire.Find("CampfireCollider").GetComponent<LevelChanger>();
        if (script.loseEnable)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("reload");
        }

    }
}