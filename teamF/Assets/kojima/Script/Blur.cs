using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blur : MonoBehaviour {

    Image image;

    bool flag = false;
    
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}

    // Update is called once per frame
    void Update() {
        if (flag)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 116.0f / 255.0f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
	}

    public void isBlur()
    {
        flag = true;
    }

    public void SwitchBlur()
    {
        if (flag)
        {
            flag = false;
        }
        else
        {
            flag = true;
        }
    }
}
