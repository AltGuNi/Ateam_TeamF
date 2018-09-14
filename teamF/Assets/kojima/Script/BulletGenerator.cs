using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class BulletGenerator : MonoBehaviour {

    [SerializeField]
    GameObject nomalbulletPrefab;
    [SerializeField]
    GameObject firebulletPrefab;
    [SerializeField]
    GameObject waterbulletPrefab;
    [SerializeField]
    GameObject woodbulletPrefab;

    [SerializeField, Space(10)]
    Vector2 speed = new Vector2(1.0f, 1.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Instance(BeseObject obj, Vector2 dir)
    {
        GameObject instance;

        switch (obj.status.bulletElement)
        {
            case BeseObject.Elements.Nomal:
                instance = Instantiate(nomalbulletPrefab);
                break;
            case BeseObject.Elements.Fire:
                instance = Instantiate(firebulletPrefab);
                break;
            case BeseObject.Elements.Water:
                instance = Instantiate(waterbulletPrefab);
                break;
            case BeseObject.Elements.Wood:
                instance = Instantiate(woodbulletPrefab);
                break;

            default:
                return;
                break;
        }

        // 場所
        instance.gameObject.transform.position = obj.gameObject.transform.position;

        // 速度
        instance.GetComponent<Bullet>().Velocity = new Vector2(dir.x * speed.x, dir.y * speed.y);

        // 当たり判定の種類を設定
        instance.GetComponent<Bullet>().colideType = obj.GetComponent<BeseObject>().colideType;

        // ステータスの反映
        instance.GetComponent<Bullet>().status.valueState = obj.GetComponent<BeseObject>().status.valueState;
    }
}
