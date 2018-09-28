using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TouchScript.Gestures;

public class Winpop : MonoBehaviour {

    public PlayerInfo playerInfo;
    public QuestInfo questInfo;
    public Text lv;
    public Text nextExperience;
    public Text experience;
    public Text gold;

    public TapGesture tapGesture;
    public float delayTime = 0.0f;
    public float doubleTime = 0.0f;
    public float doubleValue = 1.2f;

    int value = 1;      // 減らしていく値
    int type = -1;
    float countToDelayTime = 0.0f;
    float countToDoubleTime = 5.0f;
    float doubleValueBuf = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        countToDelayTime += Time.deltaTime;
        if (countToDelayTime >= delayTime)
        {
            countToDelayTime = 0.0f;
            int valueBuf = (int)(value * doubleValueBuf);
            switch (type)
            {
                case 0:
                    // 経験値の処理
                    if ((questInfo.experience - valueBuf) < 0)
                    {
                        playerInfo.currentExperience += questInfo.experience;
                        questInfo.experience = 0;
                    }
                    else
                    {
                        questInfo.experience -= valueBuf;
                        playerInfo.currentExperience += valueBuf;
                    }
                    break;
                case 1:
                    // お金の処理
                    if ((questInfo.gold - valueBuf) < 0)
                    {
                        playerInfo.gold += questInfo.gold;
                        questInfo.gold = 0;
                    }
                    else
                    {
                        questInfo.gold -= valueBuf;
                        playerInfo.gold += valueBuf;
                    }
                    break;
            }
        }

        // レベルを上げる
        if ((playerInfo.currentExperience / playerInfo.nextExperience) != 0)
        {
            int upLevel = playerInfo.currentExperience / playerInfo.nextExperience;
            playerInfo.level += upLevel;
            playerInfo.currentExperience = playerInfo.currentExperience % playerInfo.nextExperience;
        }

        lv.text = playerInfo.level.ToString();
        experience.text = playerInfo.currentExperience.ToString();
        nextExperience.text = playerInfo.nextExperience.ToString();
        gold.text = playerInfo.gold.ToString();

        countToDoubleTime += Time.deltaTime;
        if ((type >= 0) &&
            (countToDoubleTime >= doubleTime))
        {
            countToDoubleTime = 0.0f;
            doubleValueBuf *= doubleValue;
        }
    }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    // 長押し最初の処理
    private void OnTapped(object sender, EventArgs e)
    {
        
        switch (type)
        {
            case 0:
                playerInfo.currentExperience += questInfo.experience;
                questInfo.experience = 0;
                break;
            case 1:
                playerInfo.gold += questInfo.gold;
                questInfo.gold = 0;
                break;
        }
        doubleValueBuf = 1.0f;

        // ホーム画面に遷移
        if (type >= 2)
        {

        }
        if(GetComponent<Pop>().isFull)
        {
            type++;
        }
    }
}
