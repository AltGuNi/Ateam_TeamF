using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Shot : MonoBehaviour 
{
    public enum Type
    {
        Player,
        Enemey
    }
    public Type bulletGeneratorType;

    BulletGenerator bulletGenerator;
    BeseObject baseObject;

    [HideInInspector]
    public bool flag = false;
    [HideInInspector]
    public float count = 0.0f;
    [HideInInspector]
    public float radian = 0.0f;
    [HideInInspector]
    public int countBullet = 0;
    
    // Use this for initialization
    void Start () {
        if (bulletGeneratorType == Type.Player)
        {
            bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        }
        else
        {
            bulletGenerator = GameObject.Find("EnemyBulletGenerator").GetComponent<BulletGenerator>();
        }
        baseObject = this.gameObject.GetComponent<BeseObject>();
        count = baseObject.status.valueStatus.duration;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (flag)
        {
            count += Time.deltaTime;
            float duration = (baseObject.status.valueStatus.duration - baseObject.status.upSkillStatus.DownDuration) * baseObject.status.upSkillStatus.MAG_Duration;
            if (count > duration)
            {
                bulletGenerator.Instance(baseObject, radian);
                count = 0.0f;
                countBullet++;
            }
        }
        else
        {
            countBullet = 0;
        }
    }
}
