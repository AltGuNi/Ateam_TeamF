using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    [System.Serializable]
    public class Action
    {
        public float timeInterval = 1.0f;
        public int countBullet = 3;
    }

    public Action[] action;

    float countForTimeInterval = 0.0f;
    int actionCount = 0;

    SpriteRenderer spriteRenderer;
    GameObject player;
    Shot shot;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("TouchArea").transform.Find("Player").gameObject;
        shot = GetComponent<Shot>();
    }
	
	// Update is called once per frame
	void Update () {
        // 画面内に存在する場合一定間隔で弾を発射
        if (spriteRenderer.isVisible &&
            (action.Length > 0))
        {
            if (countForTimeInterval <= action[actionCount].timeInterval)
            {
                countForTimeInterval += Time.deltaTime;
            }
            else
            {
                shot.flag = true;
                Vector3 pos = player.transform.position - transform.position;
                shot.radian = Mathf.Atan2(pos.y, pos.x);
                if (shot.countBullet >= action[actionCount].countBullet)
                {
                    actionCount++;
                    countForTimeInterval = 0.0f;
                    shot.flag = false;
                }
            }
            if (actionCount >= action.Length)
            {
                actionCount = 0;
            }
        }
    }
}
