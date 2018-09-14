using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class SpriteType : MonoBehaviour {

    public enum Type
    {
        Stand = 0,
        Icon,
        Run,

        None
    }

    public Type spriteType = Type.None;

    [System.Serializable]
    public class SpriteList
    {
        public Sprite stand;
        public Sprite icon;
        public Sprite run;
    }

    public SpriteList spriteList;

    // Use this for initialization
    void Start () {

        switch (spriteType)
        {
            case Type.Stand:
                GetComponent<SpriteRenderer>().sprite = spriteList.stand;
                break;
            case Type.Icon:
                GetComponent<SpriteRenderer>().sprite = spriteList.icon;
                break;
            case Type.Run:
                GetComponent<SpriteRenderer>().sprite = spriteList.run;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
