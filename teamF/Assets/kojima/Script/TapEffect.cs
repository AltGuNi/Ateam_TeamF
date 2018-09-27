using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class TapEffect : MonoBehaviour {

    public ParticleSystem tapEffect;                // タップエフェクト
    public Camera _camera;                          // カメラの座標
    
    public TapGesture tapGesture;
    
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTap;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTap;
    }

    private void OnTap(object sender, EventArgs e)
    {
        tapEffect.transform.position = Camera.main.ScreenToWorldPoint(tapGesture.ScreenPosition) + _camera.transform.forward * 10;
        tapEffect.Play();
    }
}
