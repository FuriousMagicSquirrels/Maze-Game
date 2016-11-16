using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Ranking : MonoBehaviour {

    // Use this for initialization
    private SortedList list = new SortedList();
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        var ranking = GetComponent<Text>();
        ranking.text = "";
        foreach (var item in list.GetValueList())
        {
            ranking.text = ranking.text + item + "\n";
        }
    }
    public void add(float number, string name)
    {
        if (!list.ContainsValue(name))
        {
            while (list.ContainsKey(number)) number -= 0.001f;
            list.Add(number, name);
        } else
        {
            int index = list.IndexOfValue(name);
            list.RemoveAt(index);
            while (list.ContainsKey(number)) number -= 0.001f;
            list.Add(number, name);
        }
    }
}
