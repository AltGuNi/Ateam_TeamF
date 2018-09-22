using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Player : MonoBehaviour {

    public LongPressGesture longPressGesture;
    public ReleaseGesture releaseGesture;
    Shot shot;

    Character character;
    // Use this for initialization
    void Start () {

        shot = GetComponent<Shot>();
        character = GetComponent<Character>();
    }
	
	// Update is called once per frame
	void Update () {
        if(shot.flag)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(releaseGesture.ScreenPosition);
            float x = pos.x - gameObject.transform.position.x;
            float y = pos.y - gameObject.transform.position.y;

            //// 方向
            shot.radian = Mathf.Atan2(y, x);
        }
        // 倒されたとき時間を止め進める
        if (character.status.valueStatus.HP <= 0.0f)
        {

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
        shot.flag = true;
    }

    // 長押しから話した時の処理
    private void OnReleased(object sender, EventArgs e)
    {
        shot.flag = false;
    }
}
