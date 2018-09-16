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
        int totalRate = 0;
        int random = UnityEngine.Random.Range(0, 101);

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
        if (elementInfo != null)
        {
            random = UnityEngine.Random.Range(0, elementInfo.sprite.Length);
            if (elementInfo.sprite[random])
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = elementInfo.sprite[random];
                elements = elementInfo.elements;
            }
        }

        if (isLeft)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject.Find("Player").GetComponent<Character>().status.bulletElement = elements;
    }
}
