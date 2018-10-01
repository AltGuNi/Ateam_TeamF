using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FontWava : MonoBehaviour {

    public float upDownAlpha = 0.0f;
    public float displayTime = 0.0f;
    public float upDownFlashAlpha = 0.0f;
    public float flashWidth = 0.0f;
    public GameObject startWave = null;
    public GameObject fontGameClear = null;
    public GameObject fontGameOver = null;

    [Flags]
    private enum BitFlag
    {
        Boss = 1 << 0,
        Visible = 1 << 1,
        Flash = 1 << 2
    }

    Text text;
    float alpha = 0.0f;

    int wave = 0;
    float timeForDisplayTime = 0.0f;
    float upDownFlashAlphaBuf = 0.0f;
    GameObject nextWaveBuf = null;
    BitFlag bitFlag = 0;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.color = new Color(1, 1, 1, alpha);
        NextWave(startWave);
        startWave.GetComponent<Wave>().fontWave = this;
    }
	
	// Update is called once per frame
	void Update () {

        // ゲーム終了時
        if (fontGameClear && fontGameOver)
        {
            if (fontGameClear.activeSelf || fontGameOver.activeSelf)
            {
                this.gameObject.SetActive(false);
            }
        }

        if ((bitFlag & BitFlag.Visible) == BitFlag.Visible)
        {
            if (!((bitFlag & BitFlag.Flash) == BitFlag.Flash))
            {
                alpha += upDownAlpha;
                if (alpha >= 1.0f)
                {
                    bitFlag |= BitFlag.Flash;
                    upDownFlashAlphaBuf = -upDownFlashAlpha;
                }
            }
            else
            {
                timeForDisplayTime += Time.deltaTime;
                if (timeForDisplayTime <= displayTime)
                {
                    alpha += upDownFlashAlphaBuf;
                    if (alpha >= 1.0f)
                    {
                        alpha = 1.0f;
                        upDownFlashAlphaBuf = -upDownFlashAlpha;
                    }

                    else if (alpha <= (1.0f - flashWidth))
                    {
                        alpha = 1.0f - flashWidth;
                        upDownFlashAlphaBuf = upDownFlashAlpha;
                    }
                }
                else
                {
                    timeForDisplayTime = 0.0f;
                    bitFlag = ~bitFlag;

                    // フラッシュのフラグを伏せる
                    bitFlag |= BitFlag.Flash;
                    // Visibleのフラグを伏せる
                    bitFlag |= BitFlag.Visible;

                    bitFlag = ~bitFlag;
                }
            }
        }
        else
        {
            if (nextWaveBuf && !nextWaveBuf.activeSelf)
            {
                nextWaveBuf.SetActive(true);
            }
            alpha -= upDownAlpha;
        }
        if (alpha <= 0.0f)
        {
            alpha = 0.0f;
            nextWaveBuf = null;
        }
        text.color = new Color(1, 1, 1, alpha);
        if ((bitFlag & BitFlag.Boss) == BitFlag.Boss)
        {
            text.text = "Boss";
        }
        else
        {
            text.text = "Wave " + wave;
        }
    }

    public void NextWave(GameObject nextWave)
    {
        nextWaveBuf = nextWave;
        // フラグにVisibleのフラグを立てる
        bitFlag |= BitFlag.Visible;
        alpha = 0.0f;
        upDownFlashAlphaBuf = -upDownFlashAlpha;
        wave++;

        nextWave.GetComponent<Wave>().fontWave = this;

        if (!nextWave.GetComponent<Wave>().nextWave)
        {
            // フラグにBossのフラグを立てる
            bitFlag |= BitFlag.Boss;
        }
    }
}
