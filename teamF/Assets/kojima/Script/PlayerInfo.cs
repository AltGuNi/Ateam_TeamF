using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    string userName;                // ユーザーネーム

    int level;                  // 現在のレベル
    int currentExperience;      // 現在の経験値
    int nextExperience;         // 次のレベルまでの経験値量
    int experience;             // 今までの経験値

    public enum CharaNum
    {
        First = 0,
        Second,
        Third,
        Friend,

        Max
    }

    Character[] chara = new Character[(int)CharaNum.Max];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
