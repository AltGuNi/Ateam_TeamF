using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public GameObject nextWave;
    public bool isBoss = false;
    public GameObject fontWave;
	// Use this for initialization
	void Start ()
    {
        fontWave.GetComponent<FontWava>().NextWave(isBoss);
    }
	
	// Update is called once per frame
	void Update () {
        bool flag = false;
        // 敵の検索
        foreach (Transform enemy in gameObject.transform)
        {
            flag = true;
        }
        // 敵がいなかった場合
        if (!flag)
        {
            if (nextWave)
            {
                GameObject instance = Instantiate(nextWave);
                instance.transform.SetParent(GameObject.Find("TouchArea").transform);
            }
            // ボスウェーブの場合
            if (isBoss)
            {
                GameObject.Find("GameTime").GetComponent<GameTime>().IsResult(true);
            }
            Destroy(this.gameObject);
        }
    }
}
