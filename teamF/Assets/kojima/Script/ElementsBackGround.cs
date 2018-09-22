using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;


public class ElementsBackGround : MonoBehaviour {
    

    public bool isLeft = false;

    BeseObject.Elements elements = BeseObject.Elements.Nomal;

    BackGround.ElementsInfo elementInfo;

    // Use this for initialization
    void Start()
    {
        RnadomElement();

        if (isLeft)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent.GetComponent<BackGround>().instanceFlag)
        {
            RnadomElement();
        }
    }

    public void RnadomElement()
    {
        int totalRate = 0;
        int random = UnityEngine.Random.Range(0, 101);

        // 属性を決める
        BackGround backGround = gameObject.transform.parent.GetComponent<BackGround>();
        for (int i = 0; i < backGround.elementsSprite.Length; i++)
        {
            if (((totalRate + backGround.elementsSprite[i].rate) >= random) && (random >= totalRate))
            {
                elementInfo = backGround.elementsSprite[i];
                break;
            }
            totalRate += backGround.elementsSprite[i].rate;
        }
        // 画像を決める
        if (elementInfo != null)
        {
            random = UnityEngine.Random.Range(0, elementInfo.sprite.Length);
            if (elementInfo.sprite[random])
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = elementInfo.sprite[random];
                elements = elementInfo.elements;
            }
        }
    }

    private void OnEnable()
    {
        GetComponent<PressGesture>().Pressed += OnPressed;
    }

    private void OnDisable()
    {
        GetComponent<PressGesture>().Pressed -= OnPressed;
    }

    private void OnPressed(object sender, EventArgs e)
    {
        GameObject player = GameObject.Find("Player");
        if (player)
        {
            player.GetComponent<Character>().status.bulletElement = elements;
        }
    }
}
