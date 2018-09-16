using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {
    
    public float speed;
    
    [System.Serializable]
    public class ElementsInfo
    {
        public string name;
        
        [SerializeField, Range(0, 100)]
        public int rate;

        [SerializeField,Space(10)]
        public Sprite[] sprite;

        [HideInInspector]
        public BeseObject.Elements elements; 

        public ElementsInfo(BeseObject.Elements elements)
        {
            this.elements = elements;
            this.name = elements.ToString();
            rate = 0;
            sprite = null;
        }
    };

    public ElementsInfo[] elementsSprite = {
        new ElementsInfo(BeseObject.Elements.Fire),
        new ElementsInfo(BeseObject.Elements.Water),
        new ElementsInfo(BeseObject.Elements.Wood)};

    float startLine = 47.1f;
    float instanceLine = -37.2f;
    float endLine = -47.1f;

    bool instanceFlag = false;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -speed);
    }
	
	// Update is called once per frame
	void Update () {
        // 画面外に出る場合、新しく作る
        if (!instanceFlag &&
            gameObject.transform.position.y < instanceLine)
        {
            instanceFlag = true;
            GameObject obj = Instantiate(this.gameObject);
            obj.gameObject.transform.position = new Vector2(0.0f, startLine);
            obj.transform.SetParent(GameObject.Find("LongPressArea").transform);
        }
        // スクロールが終わった場合、消す
		if(gameObject.transform.position.y < endLine)
        {
            Destroy(this.gameObject);
        }
	}
}
