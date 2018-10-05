using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestIcon : MonoBehaviour {

    public Character player;

    public PlayerInfo playerInfo;

    public PlayerInfo.CharaNum charaNum;

    public Num num;

    [SerializeField, Space(10)]
    public Sprite iconFrame;
    public Sprite iconFramePlay;

    Image baseImage;                        // アイコンの背景

    bool isSkill = false;                   // スキル発動中の場合はtrue
    [HideInInspector]
    public float timeToActivate = 0.0f;     // スキル発動可能までの残り時間
    [HideInInspector]
    public float timeToFinish = 0.0f;       // スキル終了までの時間
    [HideInInspector]
    public bool isSkillStop = false;        // スキル発動の停止

    BeseObject.Elements buf;                // スキル発動時に記録する用
    Transform effectPos;                    // アイコンのエフェクトを発動する場所

    // Use this for initialization
    void Start()
    {
        if (playerInfo.chara[(int)charaNum])
        {
            timeToActivate = playerInfo.chara[(int)charaNum].status.skillStatus.timeToActivate;
            baseImage = gameObject.transform.Find("base").GetComponent<Image>();

            // アイコン画像の設定
            Image image = gameObject.transform.Find("icon").GetComponent<Image>();
            image.sprite = playerInfo.chara[(int)charaNum].icon;
            image.color = new Color(1, 1, 1, 1);

            effectPos = gameObject.transform.Find("effectPos");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.chara[(int)charaNum])
        {
            if (!isSkillStop)
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
            }
            
            num.num = Mathf.CeilToInt(timeToActivate);
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
        timeToActivate = playerInfo.chara[(int)charaNum].status.skillStatus.timeToActivate;

        // エフェクトの処理
        GameObject.Find("SkillEffectManager").GetComponent<SkillEffectManager>().SkillEffectPlay();

        if (charaNum == PlayerInfo.CharaNum.First)
        {
            GameObject.Find("SkillIconEffectManager").GetComponent<SkillIconEffectManager>().SkillIconBigEffectPlay(effectPos.position);
        }
        else
        {
            GameObject.Find("SkillIconEffectManager").GetComponent<SkillIconEffectManager>().SkillIconEffectPlay(effectPos.position);
        }

        // 弾を全部消す
        GameObject[] bullet = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in bullet)
        {
            obj.GetComponent<Bullet>().Destroy();
        }
        if (iconFramePlay)
        {
            gameObject.transform.Find("flame").GetComponent<Image>().sprite = iconFramePlay;
        }

        buf = player.status.bulletElement;
        player.status.upSkillStatus.Add(playerInfo.chara[(int)charaNum].status.skillStatus);
        // 回復のスキル処理
        player.status.valueStatus.HP += playerInfo.chara[(int)charaNum].status.skillStatus.CureHP;

        // プレイヤーの属性を変更
        buf = player.status.bulletElement;
        if (playerInfo.chara[(int)charaNum].status.skillStatus.ChangeElement != BeseObject.Elements.Max &&
            playerInfo.chara[(int)charaNum].status.skillStatus.ChangeElement != BeseObject.Elements.None)
        {
            player.status.bulletElement = playerInfo.chara[(int)charaNum].status.skillStatus.ChangeElement;
        }
    }

    // スキルの発動中
    public void UpdateSkill()
    {
    }

    // スキルの終了時
    public void FinishSkill()
    {
        if (iconFrame)
        {
            gameObject.transform.Find("flame").GetComponent<Image>().sprite = iconFrame;
        }

        // 属性がノーマルの場合はもとに戻す
        if (player.status.bulletElement == BeseObject.Elements.Nomal)
        {
            player.status.bulletElement = buf;
        }
        player.status.upSkillStatus.Remove(playerInfo.chara[(int)charaNum].status.skillStatus);
    }



    public void OnClick()
    {
        if (playerInfo.chara[(int)charaNum])
        {
            if (timeToActivate <= 0.0f && !isSkill && !isSkillStop)
            {
                isSkill = true;
                ActivateSkill();
                timeToFinish = playerInfo.chara[(int)charaNum].status.skillStatus.timeToFinish;
            }
        }
    }
}
