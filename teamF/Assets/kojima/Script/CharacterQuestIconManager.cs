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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChangeBase(first.transform.Find("base").GetComponent<Image>(), first);
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
            if (icon.playerInfo.chara[(int)icon.charaNum].status.SpecialtyElement == elements)
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

        switch (icon.playerInfo.chara[(int)icon.charaNum].status.SpecialtyElement)
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
