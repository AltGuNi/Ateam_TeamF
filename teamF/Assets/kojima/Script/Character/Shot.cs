using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Shot : MonoBehaviour {

    BulletGenerator bulletGenerator;
    public LongPressGesture longPressGesture;
    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        longPressGesture.LongPressed += OnLongPressed;
    }

    private void OnDisable()
    {
        longPressGesture.LongPressed -= OnLongPressed;
    }
    private void OnLongPressed(object sender, EventArgs e)
    {
        //float x = GetComponent<LongPressGesture>().ScreenPosition.x - gameObject.transform.position.x;
        //float y = GetComponent<LongPressGesture>().ScreenPosition.y - gameObject.transform.position.y;
        Debug.Log("nagaoshi");
        Debug.Log(longPressGesture.ScreenPosition.x);

        //// 方向
        //float angle = Mathf.Atan2(GetComponent<FlickGesture>().ScreenFlickVector.y, GetComponent<FlickGesture>().ScreenFlickVector.x);
        //float dirX = Mathf.Cos(angle);
        //float dirY = Mathf.Sin(angle);

        //bulletGenerator.Instance(this.gameObject.GetComponent<Character>(), new Vector2(dirX, dirY));
    }
}
