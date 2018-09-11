﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BeseObject{
    
    [SerializeField, Space(10)]
    float shotInterval = 1.0f;

    BulletGenerator bulletGenerator;
    SpriteRenderer spriteRenderer;
    float shotElapsedTime = 0.0f;

    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // 画面内に存在する場合一定間隔で弾を発射
        if (spriteRenderer.isVisible)
        {
            shotElapsedTime += Time.deltaTime;
            if (shotElapsedTime >= shotInterval)
            {
                shotElapsedTime = 0.0f;
                bulletGenerator.Instance(this, new Vector2(0.0f, -1.0f));
            }
        }
    }
}