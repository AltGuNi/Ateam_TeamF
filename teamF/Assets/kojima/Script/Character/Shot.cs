using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Shot : MonoBehaviour 
{
    BulletGenerator bulletGenerator;
    BeseObject baseObject;

    [HideInInspector]
    public bool flag = false;
    [HideInInspector]
    public float count = 0.0f;
    [HideInInspector]
    public float radian = 0.0f;
    
    // Use this for initialization
    void Start () {
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        baseObject = this.gameObject.GetComponent<BeseObject>();
        count = baseObject.status.valueStatus.duration;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (flag)
        {
            count += Time.deltaTime;
            if (count > baseObject.status.valueStatus.duration)
            {
                bulletGenerator.Instance(this.gameObject.GetComponent<Character>(), radian);
                count = 0.0f;
            }
        }
    }
}
