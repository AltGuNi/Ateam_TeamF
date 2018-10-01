using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour {

    public BeseObject obj;
    public Image hp;
    public Image redhp;
    public float value = 0.0f;
    public bool isPlayer = false;
    
    SpriteRenderer sprite;

    float maxhp = 0.0f;
    float latehp = 0.0f;
    float damagehp = 0.0f;
	// Use this for initialization
	void Start () {
        sprite = obj.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        // 座標を変える
        if (!isPlayer)
        {
            if (!obj)
            {
                Destroy(this.gameObject);
                return;
            }
           
            transform.position = new Vector3(
                obj.gameObject.transform.position.x, 
                obj.gameObject.transform.position.y - (sprite.bounds.size.y / 2.0f) + 3.0f, 
                obj.gameObject.transform.position.z);

        }

        // HPの最大値を取得
        if (maxhp == 0.0f)
        {
            maxhp = obj.status.valueStatus.HP;
            latehp = maxhp;
        }
        // 切り捨て後の値
        float floorHp;
        float floorHp2;
        if (obj.status.valueStatus.HP != latehp)
        {
            floorHp = Mathf.Floor((latehp - obj.status.valueStatus.HP) * 100.0f);
            floorHp2 = Mathf.Floor(maxhp * 100.0f);
            damagehp = floorHp / floorHp2;
        }
        floorHp = Mathf.Floor(obj.status.valueStatus.HP * 100.0f);
        floorHp2 = Mathf.Floor(maxhp * 100.0f);
        hp.fillAmount = floorHp / floorHp2;

        redhp.fillAmount = hp.fillAmount + damagehp;

        damagehp -= value;
        if (damagehp <= 0.0f)
        {
            damagehp = 0.0f;
        }

        latehp = obj.status.valueStatus.HP;
    }
}
