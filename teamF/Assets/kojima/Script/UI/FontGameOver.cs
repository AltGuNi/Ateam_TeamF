using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TouchScript.Gestures;
using UnityEngine.SceneManagement;

public class FontGameOver : MonoBehaviour {

    public TapGesture tapGesture;
    public float plusAlpha = 0.0f;
    public Blur blur;

    Image image;
    float alpha = 0.0f;
    BattleSoundManager battleSoundManager;
    // Use this for initialization
    void Start () {

        battleSoundManager = GameObject.Find("BattleSoundManager").GetComponent<BattleSoundManager>();
        battleSoundManager.StopSound(BattleSoundManager.Type.BossBGM);
        battleSoundManager.PlaySound(BattleSoundManager.Type.GameOver, true);
        image = GetComponent<Image>();
        image.color = new Color(1, 1, 1, alpha);
        blur.isBlur();
    }
	
	// Update is called once per frame
	void Update () {

        alpha += plusAlpha;
        if (alpha >= 1.0f)
        {
            alpha = 1.0f;
        }
        image.color = new Color(1, 1, 1, alpha);
    }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    // タップの処理
    private void OnTapped(object sender, EventArgs e)
    {
        if (alpha >= 1.0f)
        {
            SceneManager.LoadScene("main_menu");
        }
        else
        {
            alpha = 1.0f;
        }
    }
}
