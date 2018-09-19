using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class TapEffect : MonoBehaviour {

    public ParticleSystem tapEffect;                // タップエフェクト
    public ParticleSystem longPressEffect;          // 長押しエフェクト
    public ParticleSystem releseEffect;             // 離しエフェクト
    public Camera _camera;                          // カメラの座標

    public LongPressGesture longPressGesture;
    public ReleaseGesture releaseGesture;
    public PressGesture pressGesture;

    bool longPressFlag = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (longPressFlag)
        {
            longPressEffect.transform.position = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition) + _camera.transform.forward * 10;
            longPressEffect.Emit(1);
        }
	}

    private void OnEnable()
    {
        longPressGesture.LongPressed += OnLongPressed;
        releaseGesture.Released += OnReleased;
        pressGesture.Pressed += OnPress;
    }

    private void OnDisable()
    {
        longPressGesture.LongPressed -= OnLongPressed;
        releaseGesture.Released -= OnReleased;
        pressGesture.Pressed -= OnPress;
    }

    // 長押し最初の処理
    private void OnLongPressed(object sender, EventArgs e)
    {
        longPressFlag = true;
    }

    // 長押しから離した時の処理
    private void OnReleased(object sender, EventArgs e)
    {
        if (longPressFlag)
        {
            releseEffect.transform.position = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition) + _camera.transform.forward * 10;
            releseEffect.Emit(1);
        }
        longPressFlag = false;
    }

    private void OnPress(object sender, EventArgs e)
    {
        tapEffect.transform.position = Camera.main.ScreenToWorldPoint(pressGesture.ScreenPosition) + _camera.transform.forward * 10;
        tapEffect.Emit(1);
    }
}
