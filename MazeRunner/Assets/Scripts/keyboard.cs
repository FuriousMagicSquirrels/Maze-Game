//Team Name: Furious Magical Squirrels Team Members: Chao Wang, cwang624@gatech.edu, cwang624
//               Brandon Chiem, bchiem3 @gatech.edu, bchiem3
//               Jennifer Ma, jma76 @gatech.edu, jma76
//               Trung Nguyen, tnguyen337 @gatech.edu, tnguyen337
//               Annie Matin, amatin3 @gatech.edu, amatin3



using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class keyboard : MonoBehaviour {
    public EventSystem eventSystem;
    public GameObject selectedObject;
    private bool buttonSelected;
    private GameObject currentSelect;
    public GameObject lastSelect;
    private bool last;
    private bool first;
	// Use this for initialization
	void Start () {
        last = false;
        first = false;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            OnDisable();
        }
       
        currentSelect = eventSystem.currentSelectedGameObject;
        if (currentSelect == lastSelect && Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (last == false)
            {
                last = true;
            }
            else
            {
                last = false;
                eventSystem.SetSelectedGameObject(selectedObject);
            }
            
        }

        if (currentSelect == selectedObject && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (first == false)
            {
                first = true;
            }
            else
            {
                first = false;
                eventSystem.SetSelectedGameObject(lastSelect);
            }

        }

        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected ==false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
            


        }
        

    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
