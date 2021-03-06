﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveNomal : MonoBehaviour {

    // 出撃する時間
    public float sortieTime;
    // 止まる場所
    public float stopPosY;

    public Vector2 speed;

    float count = 0.0f;

    Rigidbody2D rigid2D;

    // Use this for initialization
    void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        count += Time.fixedDeltaTime;
        if (count >= sortieTime)
        {
            // 止まってからは横移動
            if (transform.position.y <= stopPosY)
            {
                if (transform.position.x <= -1.5f)
                {
                    rigid2D.velocity = new Vector2(speed.x, 0.0f);
                }
                else if (transform.position.x >= 1.5f)
                {
                    rigid2D.velocity = new Vector2(-speed.x, 0.0f);
                }
                // xの速度が決まっていないとき
                if (rigid2D.velocity.x == 0.0f)
                {
                    rigid2D.velocity = new Vector2(speed.x, 0.0f);
                }
            }
            // 止まる場所まで移動
            else
            {
                rigid2D.velocity = new Vector2(0.0f, -speed.y);
            }
        }
    }
}
