using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;


public class ElementsBackGround : MonoBehaviour {

    public BeseObject.Elements elements = BeseObject.Elements.Nomal;
    // Use this for initialization
    void Start()
    {
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
