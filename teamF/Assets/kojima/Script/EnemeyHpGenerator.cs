using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyHpGenerator : MonoBehaviour {

    public GameObject hpPrefab;

	// Use this for initialization
	void Start () {
        GameObject instance = Instantiate(hpPrefab);
        instance.GetComponent<UI_HP>().obj = this.gameObject.GetComponent<BeseObject>();
        instance.transform.SetParent(GameObject.Find("TouchArea").transform.Find("EnemyHp"));
        instance.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
