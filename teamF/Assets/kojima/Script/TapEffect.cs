using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class TapEffect : MonoBehaviour {

    public ParticleSystem tapEffect;                // タップエフェクト
    public ParticleSystem pressEffect;              // 押しエフェクト
    public ParticleSystem longPressEffect;          // 長押しエフェクト
    public ParticleSystem releseEffect;             // 離しエフェクト
    public Camera _camera;                          // カメラの座標

    public PressGesture pressGesture;
    public TapGesture tapGesture;
    public LongPressGesture longPressGesture;
    public ReleaseGesture releaseGesture;

    bool longPressFlag = false;
    bool pressFlag = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (longPressFlag)
        {
            longPressEffect.transform.position = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition) + _camera.transform.forward * 10;
            longPressEffect.Emit(1);

            // タップのエフェクトを遠くに飛ばす
            pressEffect.transform.position = new Vector3(0.0f, -100.0f, 0.0f);
        }
	}

    private void OnEnable()
    {
        tapGesture.Tapped += OnTap;
        pressGesture.Pressed += OnPress;
        longPressGesture.LongPressed += OnLongPressed;
        releaseGesture.Released += OnReleased;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTap;
        pressGesture.Pressed -= OnPress;
        longPressGesture.LongPressed -= OnLongPressed;
        releaseGesture.Released -= OnReleased;
    }

    private void OnTap(object sender, EventArgs e)
    {
        Debug.Log("tap");
        //tapEffect.transform.position = Camera.main.ScreenToWorldPoint(tapGesture.ScreenPosition) + _camera.transform.forward * 10;
        //tapEffect.Emit(1);
    }

    private void OnPress(object sender, EventArgs e)
    {
        if (!pressFlag)
        {
            pressEffect.transform.position = Camera.main.ScreenToWorldPoint(pressGesture.ScreenPosition) + _camera.transform.forward * 10;
            pressEffect.Emit(1);
        }
        pressFlag = true;
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
        pressFlag = false;
    }

    
}
