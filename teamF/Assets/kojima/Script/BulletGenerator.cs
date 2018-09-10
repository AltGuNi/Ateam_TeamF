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


    [SerializeField, Space(10)]
    GameObject player;
    [SerializeField]
    FlickGesture flickGesture;
    [SerializeField]
    Vector2 speed = new Vector2(1.0f, 1.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
    }

    public void Instance(BeseObject obj, Vector2 dir)
    {
        GameObject instance;

        switch (obj.Attribute)
        {
            case BeseObject.AttributeData.Nomal:
                instance = Instantiate(nomalbulletPrefab);
                break;
            case BeseObject.AttributeData.Fire:
                instance = Instantiate(firebulletPrefab);
                break;
            case BeseObject.AttributeData.Water:
                instance = Instantiate(waterbulletPrefab);
                break;

            default:
                return;
                break;
        }

        // 場所
        instance.gameObject.transform.position = obj.gameObject.transform.position;

        // 速度
        instance.GetComponent<Bullet>().Velocity = new Vector2(dir.x * speed.x, dir.y * speed.y);
    }

    private void OnFlicked(object sender, EventArgs e)
    {
        // 方向
        float angle = Mathf.Atan2(flickGesture.ScreenFlickVector.y, flickGesture.ScreenFlickVector.x);
        float dirX = Mathf.Cos(angle);
        float dirY = Mathf.Sin(angle);

        Instance(player.GetComponent<Player>(), new Vector2(dirX, dirY));
    }
}
