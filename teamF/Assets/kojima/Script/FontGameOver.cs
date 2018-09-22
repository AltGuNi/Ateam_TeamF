﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TouchScript.Gestures;

public class FontGameOver : MonoBehaviour {

    public TapGesture tapGesture;
    public float plusAlpha = 0.0f;

    Text text;
    float alpha = 0.0f;
    // Use this for initialization
    void Start () {

        text = GetComponent<Text>();
        text.color = new Color(1, 1, 1, alpha);
    }
	
	// Update is called once per frame
	void Update () {

        alpha += plusAlpha;
        if (alpha >= 1.0f)
        {
            alpha = 1.0f;
        }
        text.color = new Color(1, 1, 1, alpha);
    }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    // タップの処理
    private void OnTapped(object sender, EventArgs e)
    {
        if (alpha >= 1.0f)
        {
        }
        else
        {
            alpha = 1.0f;
        }
    }
}
