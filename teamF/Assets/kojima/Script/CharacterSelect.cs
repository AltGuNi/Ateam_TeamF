using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class CharacterSelect : MonoBehaviour {

    [SerializeField]
    GameObject character;

    Vector2 PlayerPos = new Vector2(0.0f, -2.7f);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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
        Destroy(GameObject.Find("Player"));
        GameObject obj = Instantiate(character);
        obj.transform.position = PlayerPos;
        obj.name = "Player";
    }
}
