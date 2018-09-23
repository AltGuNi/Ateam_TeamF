using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontWava : MonoBehaviour {

    public float minusAlpha = 0.0f;

    Text text;
    float alpha = 1.0f;

    int wave = 0;
    bool isBoss = false;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.color = new Color(1, 1, 1, alpha);
    }
	
	// Update is called once per frame
	void Update () {

        alpha -= minusAlpha;
        if (alpha <= 0.0f)
        {
            alpha = 0.0f;
        }
        text.color = new Color(1, 1, 1, alpha);
        if (isBoss)
        {
            text.text = "Boss";
        }
        else
        {
            text.text = "Wave " + wave;
        }
    }

    public void NextWave(bool _isBoss)
    {
        alpha = 1.0f;
        wave++;
        isBoss = _isBoss;
    }
}
