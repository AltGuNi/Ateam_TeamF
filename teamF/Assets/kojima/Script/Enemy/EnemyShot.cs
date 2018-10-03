using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    [System.Serializable]
    public class Action
    {
        public float timeInterval = 1.0f;
        public int countBullet = 3;
        public BeseObject.Elements element = BeseObject.Elements.None;
        public bool isOne = false;
        [HideInInspector]
        public bool isFinish = false;
    }

    public Action[] action;

    float countForTimeInterval = 0.0f;
    int actionCount = 0;

    SpriteRenderer spriteRenderer;
    GameObject player;
    BeseObject enemy;
    Shot shot;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("TouchArea").transform.Find("Player").gameObject;
        enemy = GetComponent<Enemy>();
        shot = GetComponent<Shot>();
        for (int i = 0; i < action.Length; i++)
        {
            if (action[i].element == BeseObject.Elements.None)
            {
                action[i].element = enemy.status.bulletElement;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        // 画面内に存在する場合一定間隔で弾を発射
        if ((action.Length > 0))
        {
            if (countForTimeInterval <= action[actionCount].timeInterval)
            {
                countForTimeInterval += Time.deltaTime;
            }
            else
            {
                shot.flag = true;
                if (action[actionCount].element != BeseObject.Elements.None &&
                    action[actionCount].element != BeseObject.Elements.Max)
                {
                    enemy.status.bulletElement = action[actionCount].element;
                }
                Vector3 pos = player.transform.position - transform.position;
                shot.radian = Mathf.Atan2(pos.y, pos.x);
                if (shot.countBullet >= action[actionCount].countBullet)
                {
                    if (action[actionCount].isOne)
                    {
                        action[actionCount].isFinish = true;
                    }
                    actionCount++;
                    countForTimeInterval = 0.0f;
                    shot.flag = false;
                    if (actionCount >= action.Length)
                    {
                        actionCount = 0;
                    }

                    Action buf = action[actionCount];
                    while (action[actionCount].isFinish)
                    {
                        actionCount++;
                        if (actionCount >= action.Length)
                        {
                            actionCount = 0;
                        }
                        if (buf == action[actionCount])
                        {
                            break;
                        }
                    }
                }
            }
            if (actionCount >= action.Length)
            {
                actionCount = 0;
            }
        }
    }
}
