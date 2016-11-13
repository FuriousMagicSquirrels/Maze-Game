using UnityEngine;
using System.Collections;

public class InstantiateItems : MonoBehaviour {

    // make array of item prefabs
    int numPrefabs = 1; // set to 2 when use speedpot/some other item
    public int numItemsInGame = 14;
    string[] prefabs = { "StunBombItem","SpeedPotion" };


	// Use this for initialization
	void Start () {
        // get items
        // pick a random #
        // access prefab array with it 
        // instantiate prefab at item's position
        for (int i = 0; i < numItemsInGame; i++) {
            int rand = Random.Range(0, numPrefabs);            
            string prefabName = prefabs[rand];            

            string objName = "Item (" + i + ")";         
            GameObject obj = GameObject.Find(objName);
            Vector3 pos = obj.transform.position;

            Instantiate(Resources.Load(prefabName), pos, Quaternion.identity);

            // inactivate object ghost
            obj.SetActive(false);
        }

    }
	

}
