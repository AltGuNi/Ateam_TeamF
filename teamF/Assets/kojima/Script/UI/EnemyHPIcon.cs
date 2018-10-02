using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPIcon : MonoBehaviour {

    public BeseObject obj;

    public Sprite normal;
    public Sprite fire;
    public Sprite wood;
    public Sprite water;

    Image image;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (obj.status.bulletElement)
        {
            case BeseObject.Elements.Nomal:
                image.sprite = normal;
                break;
            case BeseObject.Elements.Fire:
                image.sprite = fire;
                break;
            case BeseObject.Elements.Wood:
                image.sprite = wood;
                break;
            case BeseObject.Elements.Water:
                image.sprite = water;
                break;
        }
    }
}
