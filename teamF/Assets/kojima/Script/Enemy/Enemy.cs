using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BeseObject{
    

    [SerializeField, Space(10)]
    public int experence = 0;
    public int gold = 0;
    
    QuestInfo questInfo;

    // Use this for initialization
    void Start () {
        questInfo = GameObject.Find("QuestInfo").GetComponent<QuestInfo>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void LateUpdate() {
        if (status.valueStatus.HP <= 0.0f)
        {
            if(Time.timeScale >= 0.5f)
            {
                GameObject.Find("CharacterQuestIconManager").GetComponent<CharacterQuestIconManager>().AdvanceSkillTime(status.bulletElement);
                questInfo.experience += experence;
                questInfo.gold += gold;
                GameObject.Find("ExplosionEffectManager").GetComponent<ExplosionEffectManager>().ExploisonEffectPlay(transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
