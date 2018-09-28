using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TouchScript.Gestures;

public class LongPressEffect : MonoBehaviour {

    public LongPressGesture longPressGesture;
    public ReleaseGesture releaseGesture;

    bool isStart = false;
    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float scale = 200.0f;
        if (isStart)
        {
            transform.localScale *= 1.5f;
            if (transform.localScale.x >= scale)
            {
                transform.localScale = new Vector3(scale, transform.localScale.y, 1.0f);
            }
            if (transform.localScale.y >= scale)
            {
                transform.localScale = new Vector3(transform.localScale.x, scale, 1.0f);
            }

            transform.position = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition);
            transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, 0.0f);
        }
        else
        {
            transform.localScale *= 0.8f;
            if (transform.localScale.x <= 0.01f)
            {
                transform.localScale = new Vector3(0.0f, transform.localScale.y, 1.0f);
            }
            if (transform.localScale.y <= 0.01f)
            {
                transform.localScale = new Vector3(transform.localScale.x, 0.0f, 1.0f);
            }
        }
        
    }

    private void OnEnable()
    {
        longPressGesture.LongPressed += OnLongPressed;
        releaseGesture.Released += OnReleased;
    }

    private void OnDisable()
    {
        longPressGesture.LongPressed -= OnLongPressed;
        releaseGesture.Released -= OnReleased;
    }

    // 長押し最初の処理
    private void OnLongPressed(object sender, EventArgs e)
    {
        isStart = true;
        transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
    }

    // 長押しから離した時の処理
    private void OnReleased(object sender, EventArgs e)
    {
        isStart = false;
    }
}
