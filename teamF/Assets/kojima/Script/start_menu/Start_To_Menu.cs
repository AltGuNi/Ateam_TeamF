using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;
using UnityEngine.SceneManagement;

public class Start_To_Menu : MonoBehaviour {
    public string move_scene = "main_menu";

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
        SceneManager.LoadScene(move_scene);
    }

}
