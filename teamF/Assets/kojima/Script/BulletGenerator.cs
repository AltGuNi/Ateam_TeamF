using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class BulletGenerator : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject player;
    [SerializeField]
    FlickGesture flickGesture;
    [SerializeField]
    Vector2 speed = new Vector2(1.0f, 1.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
    }

    private void OnFlicked(object sender, EventArgs e)
    {
        var instance = Instantiate(bulletPrefab);

        // 場所
        instance.gameObject.transform.position = player.gameObject.transform.position;

        // 速度
        float angle = Mathf.Atan2(flickGesture.ScreenFlickVector.y, flickGesture.ScreenFlickVector.x);
        float speedX = Mathf.Cos(angle);
        float speedY = Mathf.Sin(angle);

        //float speedX = flickGesture.ScreenFlickVector.x / 10.0f;
        //float speedY = flickGesture.ScreenFlickVector.y / 10.0f;
        instance.GetComponent<Bullet>().Velocity = new Vector2(speedX * speed.x, speedY * speed.y);
    }
}
