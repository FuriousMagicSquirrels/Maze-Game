
using UnityEngine;
using System.Collections;

public class minimap : MonoBehaviour
{



    void Awake()
    {
        Transform fire = GameObject.Find("Campfire").transform;
        if (fire.Find("CampfireCollider").GetComponent<LevelChanger>().loseEnable)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("reload");
        }

    }
}