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
    public Text experience;
    public Text gold;

    public TapGesture tapGesture;

    int value = 1;      // 減らしていく値
    int type = -1;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    switch (type)
        {
            case 0:
                // 経験値の処理
                if ((questInfo.experience - value) < 0)
                {
                    playerInfo.currentExperience += questInfo.experience;
                    questInfo.experience = 0;
                }
                else
                {
                    questInfo.experience -= value;
                    playerInfo.currentExperience += value;
                }
                break;
            case 1:
                // お金の処理
                if ((questInfo.gold - value) < 0)
                {
                    playerInfo.gold += questInfo.gold;
                    questInfo.gold = 0;
                }
                else
                {
                    questInfo.gold -= value;
                    playerInfo.gold += value;
                }
                break;
        }
        // レベルを上げる
        if ((playerInfo.currentExperience / playerInfo.nextExperience) != 0)
        {
            int upLevel = playerInfo.currentExperience / playerInfo.nextExperience;
            playerInfo.level += upLevel;
            playerInfo.currentExperience = playerInfo.currentExperience % playerInfo.nextExperience;
        }

        lv.text = "LV" + playerInfo.level;
        experience.text = "経験値\n" + playerInfo.currentExperience + " / " + playerInfo.nextExperience;
        gold.text = "お金\n" + playerInfo.gold;
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
