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
    float count = 0.0f;
    [HideInInspector]
    public Vector2 dir = Vector2.zero;
    
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
                bulletGenerator.Instance(this.gameObject.GetComponent<Character>(), new Vector2(dir.x, dir.y));
                count = 0.0f;
            }
        }
        else
        {
            count = baseObject.status.valueStatus.duration;
        }
    }
}
