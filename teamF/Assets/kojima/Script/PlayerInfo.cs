using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public Character player;

    [SerializeField, Space(10)]
    public string userName;                // ユーザーネーム

    public int level;                  // 現在のレベル
    public int currentExperience;      // 現在の経験値
    public int nextExperience;         // 次のレベルまでの経験値量
    public int experience;             // 今までの経験値

    public enum CharaNum
    {
        First = 0,
        Second,
        Third,
        Friend,

        Max
    }

    public Character[] chara = new Character[(int)CharaNum.Max];

    BeseObject.Status status = new BeseObject.Status();

    // Use this for initialization
    void Start () {
        for (int i = 0; i < (int)CharaNum.Max; i++)
        {
            if(chara[i])
            {
                status.valueStatus.attack += chara[i].status.valueStatus.attack;
            }
        }
        player.status.valueStatus = status.valueStatus;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
