using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shot : MonoBehaviour {

    public BeseObject obj;
    public Image shotGuage;
    
    float maxDuration = 0.0f;
    Shot shot;
    // Use this for initialization
    void Start()
    {
        shot = obj.GetComponent<Shot>();
    }

    // Update is called once per frame
    void Update()
    {
        // HPの最大値を取得
        if (maxDuration == 0.0f)
        {
            maxDuration = obj.status.valueStatus.duration;
        }
        // 切り捨て後の値
        float floorHp;
        float floorHp2;
        floorHp = Mathf.Floor(shot.count * 100.0f);
        floorHp2 = Mathf.Floor(maxDuration * 100.0f);

        shotGuage.fillAmount = floorHp / floorHp2;
        
    }
}
