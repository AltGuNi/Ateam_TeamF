using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour {

    public GameObject pop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (pop.activeSelf)
        {
            pop.SetActive(false);
        }
        else
        {
            pop.SetActive(true);
        }
    }
}
