using UnityEngine;
using System.Collections;

public class CreateInanimObsts : MonoBehaviour {

    // make array of item prefabs
    int numPrefabs = 3;
    public int numItemsInGame = 16;
    string[] prefabs = {"Trunk_Lod0", "Big_box", "Small_box" };


    // Use this for initialization
    void Start()
    {
        // get items
        // pick a random #
        // access prefab array with it 
        // instantiate prefab at item's position
        for (int i = 0; i < numItemsInGame; i++)
        {
            int rand = Random.Range(0, numPrefabs);
            string prefabName = prefabs[rand];

            string objName = "InanimateObstacle (" + i + ")";
            GameObject obj = GameObject.Find(objName);
            
            Vector3 pos = obj.transform.position;
            //print("pos:" + pos);

            Instantiate(Resources.Load(prefabName), pos, Quaternion.identity);

            // make ghost obj inactive (and invisible)
            obj.SetActive(false);
            //MeshRenderer rend = obj.GetComponent<MeshRenderer>();
            //rend.Set(false);
        }

    }
}
