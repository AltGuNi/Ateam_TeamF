using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopTap : MonoBehaviour {

    public float upDownAlpha = 0.02f;

    Image image;
    float alpha = 0.0f;
    float upDownAlphaBuf = 0.0f;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        upDownAlphaBuf = upDownAlpha;
    }
	
	// Update is called once per frame
	void Update () {
        alpha += upDownAlphaBuf;
        if (alpha >= 1.0f)
        {
            alpha = 1.0f;
            upDownAlphaBuf = -upDownAlpha;
        }
        else if (alpha <= 0.0f)
        {
            alpha = 0.0f;
            upDownAlphaBuf = upDownAlpha;
        }

        image.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
