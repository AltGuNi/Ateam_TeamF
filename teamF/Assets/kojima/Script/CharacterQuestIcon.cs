using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestIcon : MonoBehaviour {

    public Character player;

    public PlayerInfo playerInfo;

    public PlayerInfo.CharaNum charaNum;

    [SerializeField, Space(10)]
    public Sprite icon;
    public Sprite iconFrame;
    public Sprite iconFramePlay;

    Image baseImage;                        // アイコンの背景

    bool isSkill = false;                   // スキル発動中の場合はtrue
    float timeToActivate = 0.0f;            // スキル発動可能までの残り時間
    float timeToFinish = 0.0f;              // スキル終了までの時間

    // Use this for initialization
    void Start()
    {
        if (playerInfo.chara[(int)charaNum])
        {
            timeToActivate = playerInfo.chara[(int)charaNum].status.skillStatus.timeToActivate;
            baseImage = gameObject.transform.GetChild(0).GetComponent<Image>();

            // アイコン画像の設定
            gameObject.transform.GetChild(2).GetComponent<Image>().sprite = icon;
            gameObject.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInfo.chara[(int)charaNum])
        {
            if (!isSkill)
            {
                // スキル発動までの時間を進める
                timeToActivate -= Time.deltaTime;
                if (timeToActivate <= 0.0f)
                {
                    timeToActivate = 0.0f;
                }
            }
            else
            {
                // スキル終了までの時間を進める
                timeToFinish -= Time.deltaTime;
                UpdateSkill();
                if (timeToFinish <= 0.0f)
                {
                    timeToFinish = 0.0f;
                    isSkill = false;
                    FinishSkill();
                    timeToActivate = playerInfo.chara[(int)charaNum].status.skillStatus.timeToActivate;
                }
            }

            // アイコンの背景の処理
            // 切り捨て後の値
            float floorTime = Mathf.Floor(timeToActivate * 100.0f);
            float floorTime2 = Mathf.Floor(playerInfo.chara[(int)charaNum].status.skillStatus.timeToActivate * 100.0f);

            baseImage.fillAmount = 1.0f - floorTime / floorTime2;
        }
    }


    // スキルの発動時
    public void ActivateSkill()
    {
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = iconFramePlay;
        player.status.valueStatus.attack += playerInfo.chara[(int)charaNum].status.skillStatus.UpATK;
    }

    // スキルの発動中
    public void UpdateSkill()
    {
    }

    // スキルの終了時
    public void FinishSkill()
    {
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = iconFrame;
        player.status.valueStatus.attack -= playerInfo.chara[(int)charaNum].status.skillStatus.UpATK;
    }



    public void OnClick()
    {
        if (playerInfo.chara[(int)charaNum])
        {
            if (timeToActivate <= 0.0f && !isSkill)
            {
                isSkill = true;
                ActivateSkill();
                timeToFinish = playerInfo.chara[(int)charaNum].status.skillStatus.timeToFinish;
            }
        }
    }
}
