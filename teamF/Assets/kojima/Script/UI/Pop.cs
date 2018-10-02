using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour {

    bool isActive = false;
    [HideInInspector]
    public bool isFull = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y + 0.2f,
                transform.localScale.z
                );

            if (transform.localScale.y >= 1.0f)
            {
                transform.localScale = new Vector3(
                 transform.localScale.x,
                 1.0f,
                 transform.localScale.z
                 );
            }
        }
        else
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y - 0.2f,
                transform.localScale.z
                );

            if (transform.localScale.y <= 0.0f)
            {
                transform.localScale = new Vector3(
                 transform.localScale.x,
                 0.0f,
                 transform.localScale.z
                 );
            }
        }
        if (transform.localScale.y >= 1.0f)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
	}

    public void SwitchPop()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }

    public void ClosePop()
    {
        isActive = false;
    }
}
