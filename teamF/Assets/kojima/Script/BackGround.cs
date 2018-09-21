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
        new ElementsInfo(BeseObject.Elements.Wood),
        new ElementsInfo(BeseObject.Elements.Water)};

    float startLine = 47.1f;
    float instanceLine = -37.2f;
    float endLine = -47.1f;

    [HideInInspector]
    public bool instanceFlag = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        // スクロールが終わった場合、移動
        instanceFlag = false;

        if (gameObject.transform.position.y < endLine)
        {
            instanceFlag = true;
            transform.position = new Vector2(0.0f, 121.0f);
        }
	}

    void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector2(0.0f, -speed));
    }
}
