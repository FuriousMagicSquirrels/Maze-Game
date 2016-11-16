using UnityEngine;
using System.Collections;
public class ReportDistance : MonoBehaviour {

    // Use this for initialization
    GameObject finish;
    public Ranking ranking;
    void Start () {
        finish = GameObject.Find("Finish");
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(finish.transform.position, transform.position);
        ranking.add(dist, this.name);
    }
}
