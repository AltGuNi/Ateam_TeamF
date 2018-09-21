using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public GameObject nextWave;
	// Use this for initialization
	void Start () {
        
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
            Destroy(this.gameObject);
        }
    }
}
