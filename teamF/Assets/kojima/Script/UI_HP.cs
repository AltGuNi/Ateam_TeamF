using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour {

    public Character player;
    public Image hp;
    public Image redhp;
    public float value = 0.0f;

    float maxhp = 0.0f;
    float latehp = 0.0f;
    float damagehp = 0.0f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // HPの最大値を取得
        if (maxhp == 0.0f)
        {
            maxhp = player.status.valueStatus.HP;
            latehp = maxhp;
        }
        // 切り捨て後の値
        float floorHp;
        float floorHp2;
        if (player.status.valueStatus.HP != latehp)
        {
            floorHp = Mathf.Floor((latehp - player.status.valueStatus.HP) * 100.0f);
            floorHp2 = Mathf.Floor(maxhp * 100.0f);
            damagehp = floorHp / floorHp2;
        }
        floorHp = Mathf.Floor(player.status.valueStatus.HP * 100.0f);
        floorHp2 = Mathf.Floor(maxhp * 100.0f);
        hp.fillAmount = floorHp / floorHp2;
        Debug.Log(maxhp);

        redhp.fillAmount = hp.fillAmount + damagehp;

        damagehp -= value;
        if (damagehp <= 0.0f)
        {
            damagehp = 0.0f;
        }

        latehp = player.status.valueStatus.HP;
    }
}
