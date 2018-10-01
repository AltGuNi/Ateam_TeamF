using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestIconManager : MonoBehaviour {
    public CharacterQuestIcon first;
    public CharacterQuestIcon second;
    public CharacterQuestIcon third;
    public CharacterQuestIcon friend;

    [SerializeField, Space(10)]
    public Sprite nomal;
    public Sprite fire;
    public Sprite wood;
    public Sprite water;

    [SerializeField, Space(10)]
    public Sprite nomalBig;
    public Sprite fireBig;
    public Sprite woodBig;
    public Sprite waterBig;

    [SerializeField, Space(10)]
    public Sprite iconFrameBig;
    public Sprite iconFramePlayBig;
    public Sprite iconFrame;
    public Sprite iconFramePlay;

    [SerializeField, Space(10)]
    public GameObject wave;

    // Use this for initialization
    void Start () {
        if (iconFrameBig) first.iconFrame = iconFrameBig;
        if (iconFramePlayBig) first.iconFramePlay = iconFramePlayBig;
        if (iconFrame)
        {
            second.iconFrame = iconFrame;
            third.iconFrame = iconFrame;
            friend.iconFrame = iconFrame;
        }
        if (iconFramePlay)
        { 
            second.iconFramePlay = iconFramePlay;
            third.iconFramePlay = iconFramePlay;
            friend.iconFramePlay = iconFramePlay;
        }

        Image image = first.transform.Find("base").GetComponent<Image>();
        switch (first.playerInfo.chara[(int)first.charaNum].status.specialtyElement)
        {
            case BeseObject.Elements.Nomal:
                image.sprite = nomalBig;
                break;
            case BeseObject.Elements.Fire:
                image.sprite = fireBig;
                break;
            case BeseObject.Elements.Wood:
                image.sprite = woodBig;
                break;
            case BeseObject.Elements.Water:
                image.sprite = waterBig;
                break;
        }
        //ChangeBase(first.transform.Find("base").GetComponent<Image>(), first);
        ChangeBase(second.transform.Find("base").GetComponent<Image>(), second);
        ChangeBase(third.transform.Find("base").GetComponent<Image>(), third);
        ChangeBase(friend.transform.Find("base").GetComponent<Image>(), friend);
    }

    // Update is called once per frame
    void Update () {
        bool flag = false;
        foreach (Transform obj in wave.transform)
        {
            if(obj.gameObject.activeSelf)
            {
                flag = true;
            }
        }
        // 次のウェーブに移動中
        first.isSkillStop = !flag;
        second.isSkillStop = !flag;
        third.isSkillStop = !flag;
        friend.isSkillStop = !flag;
    }

    public void AdvanceSkillTime(BeseObject.Elements elements)
    {
        AdvanceSkillTimeIcon(first, elements);
        AdvanceSkillTimeIcon(second, elements);
        AdvanceSkillTimeIcon(third, elements);
        AdvanceSkillTimeIcon(friend, elements);
    }

    public void AdvanceSkillTimeIcon(CharacterQuestIcon icon, BeseObject.Elements elements)
    {
        if (icon.playerInfo.chara[(int)icon.charaNum])
        {
            if (icon.playerInfo.chara[(int)icon.charaNum].status.specialtyElement == elements)
            {
                icon.timeToActivate -= icon.playerInfo.chara[(int)icon.charaNum].status.skillStatus.timeToActivate * 0.1f;
            }
        }
    }

    public void ChangeBase(Image image, CharacterQuestIcon icon)
    {
        if (!icon.playerInfo.chara[(int)icon.charaNum])
        {
            return;
        }

        switch (icon.playerInfo.chara[(int)icon.charaNum].status.specialtyElement)
        {
            case BeseObject.Elements.Nomal:
                image.sprite = nomal;
                break;
            case BeseObject.Elements.Fire:
                image.sprite = fire;
                break;
            case BeseObject.Elements.Wood:
                image.sprite = wood;
                break;
            case BeseObject.Elements.Water:
                image.sprite = water;
                break;
        }
    }
}
