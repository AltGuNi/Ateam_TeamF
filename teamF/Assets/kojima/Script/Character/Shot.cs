using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Shot : MonoBehaviour 
{

    BulletGenerator bulletGenerator;

    public LongPressGesture longPressGesture;
    public ReleaseGesture releaseGesture;

    public float shotInterval = 0.3f;

    [HideInInspector]
    public bool flag = false;
    float count = 0.0f;

    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        count = shotInterval;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (flag)
        {
            count += Time.deltaTime;
            if (count > this.gameObject.GetComponent<Character>().status.valueStatus.bounceSpeed)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition);
                float x = pos.x - gameObject.transform.position.x;
                float y = pos.y - gameObject.transform.position.y;

                //// 方向
                float angle = Mathf.Atan2(y, x);
                float dirX = Mathf.Cos(angle);
                float dirY = Mathf.Sin(angle);
                bulletGenerator.Instance(this.gameObject.GetComponent<Character>(), new Vector2(dirX, dirY));
                count = 0.0f;
            }
        }
        else
        {
            count = shotInterval;
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
        flag = true;
    }

    // 長押しから話した時の処理
    private void OnReleased(object sender, EventArgs e)
    {
        flag = false;
    }
    
}
