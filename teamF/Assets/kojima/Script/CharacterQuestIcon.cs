using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuestIcon : MonoBehaviour {

    public PlayerInfo playerInfo;

    public PlayerInfo.CharaNum charaNum;

    [System.Serializable]
    public class Skill
    {
        public float UpATK = 0.0f;
    };

    public Skill skill;

    bool isSkill = false;                   // スキル発動中の場合はtrue
    float timeToActivate = 0.0f;            // スキル発動可能までの残り時間
    float timeToFinish = 0.0f;              // スキル終了までの時間

    // Use this for initialization
    void Start()
    {
        timeToActivate = playerInfo.chara[(int)charaNum].status.valueState.timeToActivate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSkill)
        {
            timeToActivate -= Time.deltaTime;
            if (timeToActivate <= 0.0f)
            {
                timeToActivate = 0.0f;
            }
        }
        else
        {
            timeToFinish -= Time.deltaTime;
            UpdateSkill();
            if (timeToFinish <= 0.0f)
            {
                timeToFinish = 0.0f;
                isSkill = false;
                FinishSkill();
                timeToActivate = playerInfo.chara[(int)charaNum].status.valueState.timeToActivate;
            }
        }
    }


    // スキルの発動時
    public void ActivateSkill()
    {
        playerInfo.player.status.valueState.attack += skill.UpATK;
    }

    // スキルの発動中
    public void UpdateSkill()
    {
    }

    // スキルの終了時
    public void FinishSkill()
    {
        playerInfo.player.status.valueState.attack -= skill.UpATK;
    }



    public void OnClick()
    {
        if (timeToActivate <= 0.0f && !isSkill)
        {
            isSkill = true;
            ActivateSkill();
            timeToFinish = playerInfo.chara[(int)charaNum].status.valueState.timeToFinish;
        }
    }
}
