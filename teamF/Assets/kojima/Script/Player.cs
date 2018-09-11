using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Player : BeseObject {
    
    BulletGenerator bulletGenerator;

    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnEnable()
    {
        GetComponent<FlickGesture>().Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked -= OnFlicked;
    }
    private void OnFlicked(object sender, EventArgs e)
    {
        // 方向
        float angle = Mathf.Atan2(GetComponent<FlickGesture>().ScreenFlickVector.y, GetComponent<FlickGesture>().ScreenFlickVector.x);
        float dirX = Mathf.Cos(angle);
        float dirY = Mathf.Sin(angle);

        bulletGenerator.Instance(this.gameObject.GetComponent<Player>(), new Vector2(dirX, dirY));
    }

}
