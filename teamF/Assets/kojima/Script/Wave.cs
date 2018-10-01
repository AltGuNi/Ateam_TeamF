﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public GameObject nextWave;

    [HideInInspector]
    public FontWava fontWave;
    GameTime gameTime;
	// Use this for initialization
	void Start ()
    {
        if (!nextWave)
        {
            gameTime = GameObject.Find("GameTime").GetComponent<GameTime>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        bool flag = false;
        // 敵の検索
        foreach (Transform enemy in gameObject.transform)
        {
            flag = true;
        }
        // 敵がいなかった場合
        if (!flag)
        {
            // ボスウェーブの場合
            if (!nextWave)
            {
                gameTime.IsResult(true);
            }
            else
            {
                if (nextWave)
                {
                    fontWave.NextWave(nextWave);
                }
            }
            this.gameObject.SetActive(false);
        }
    }
}
