using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField, Space(10)]
    public string userName;                // ユーザーネーム

    public int level;                  // 現在のレベル
    public int currentExperience;      // 現在の経験値
    public int nextExperience;         // 次のレベルまでの経験値量
    public int gold;                   // 所持金
    public int colorStone;             // カラーストーン 

    public enum CharaNum
    {
        First = 0,
        Second,
        Third,
        Friend,

        Max
    }

    public Character[] chara = new Character[(int)CharaNum.Max];
    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}
}
