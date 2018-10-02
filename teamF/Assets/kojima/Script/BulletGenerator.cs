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

    public AudioClip Nomal;
    public AudioClip Wood;
    public AudioClip Fire;
    public AudioClip Water;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

    public void Instance(BeseObject obj, float radian)
    {
        GameObject instance;

        switch (obj.status.bulletElement)
        {
            case BeseObject.Elements.Nomal:
                instance = Instantiate(nomalbulletPrefab);
                audioSource.PlayOneShot (Nomal);
                break;
            case BeseObject.Elements.Fire:
                instance = Instantiate(firebulletPrefab);
                audioSource.PlayOneShot (Fire);
                break;
            case BeseObject.Elements.Water:
                instance = Instantiate(waterbulletPrefab);
                audioSource.PlayOneShot (Water);
                break;
            case BeseObject.Elements.Wood:
                instance = Instantiate(woodbulletPrefab);
                audioSource.PlayOneShot (Wood);
                break;

            default:
                return;
                break;
        }

        // 場所
        instance.gameObject.transform.position = obj.gameObject.transform.position;

        // 速度
        float speed = (obj.status.valueStatus.bounceSpeed + obj.status.UpSkillStatus.UpBounceSpeed) * obj.status.UpSkillStatus.MAG_BounceSpeed;
        float dirX = Mathf.Cos(radian);
        float dirY = Mathf.Sin(radian);
        instance.GetComponent<Bullet>().velocity = new Vector2(dirX * speed, dirY * speed);

        // 当たり判定の種類を設定
        instance.GetComponent<Bullet>().colideType = obj.GetComponent<BeseObject>().colideType;
        // ステータスの反映
        instance.GetComponent<Bullet>().status = obj.GetComponent<BeseObject>().status;

        // 親の設定
        instance.transform.SetParent(GameObject.Find("TouchArea").transform);

        // 角度
        instance.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, radian * Mathf.Rad2Deg - 90.0f));
    }
}
