using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    [SerializeField]
    GameObject backGroundPrefab;
    [SerializeField]
    float speed;
    
    float startLine = 53.0f;
    float instanceLine = -43.0f;
    float endLine = -53.0f;

    bool instanceFlag = false;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -speed);
    }
	
	// Update is called once per frame
	void Update () {
        if (!instanceFlag &&
            gameObject.transform.position.y < instanceLine)
        {
            instanceFlag = true;
            GameObject obj = Instantiate(backGroundPrefab);
            obj.gameObject.transform.position = new Vector2(0.0f, startLine);
        }
		if(gameObject.transform.position.y < endLine)
        {
            Destroy(this.gameObject);
        }
	}
}
