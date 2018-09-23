using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BeseObject{

    [SerializeField, Space(10)]
    public int experence = 0;
    public int gold = 0;

    BulletGenerator bulletGenerator;
    SpriteRenderer spriteRenderer;
    float shotElapsedTime = 0.0f;

    CharacterQuestIconManager icon;
    QuestInfo questInfo;

    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("EnemyBulletGenerator").GetComponent<BulletGenerator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        icon = GameObject.Find("CharacterQuestIconManager").GetComponent<CharacterQuestIconManager>();
        questInfo = GameObject.Find("QuestInfo").GetComponent<QuestInfo>();
    }
	
	// Update is called once per frame
	void Update () {
        // 画面内に存在する場合一定間隔で弾を発射
        if (spriteRenderer.isVisible)
        {
            shotElapsedTime += Time.deltaTime;
            if (shotElapsedTime >= status.valueStatus.duration)
            {
                shotElapsedTime = 0.0f;
                bulletGenerator.Instance(this, Mathf.Deg2Rad * -90);
            }
        }
    }

    void LateUpdate() {

        if (status.valueStatus.HP <= 0.0f)
        {
            if(Time.timeScale >= 0.5f)
            {
                icon.AdvanceSkillTime(status.SpecialtyElement);
                questInfo.experience += experence;
                questInfo.gold += gold;
                Destroy(this.gameObject);
            }
        }
    }
}
