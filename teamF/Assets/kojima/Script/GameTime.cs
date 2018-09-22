using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour {

    public GameObject blur;
    public GameObject winPop;
    public GameObject losePop;
    public float slowSpeed;
    public int resultTime;

    float timeScale = 1.0f;
    int count = 0;
    bool isResult = false;
    bool isWin = false;

    [HideInInspector]
    public bool isSlow = false;

	// Use this for initialization
	void Start () {
        count = resultTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (isSlow)
        {
            timeScale -= slowSpeed;
            if (timeScale <= 0.0f)
            {
                timeScale = 0.0f;
            }
        }
        else
        {
            count++;
            if (count >= resultTime)
            {
                count = resultTime;
                timeScale += slowSpeed;
                if (timeScale >= 1.0f)
                {
                    timeScale = 1.0f;
                }
            }
        }
        if (Time.timeScale != 0.0f)
        {
            Time.timeScale = timeScale;

            // リザルトを出す
            if (Time.timeScale >= 1.0f)
            {
                if (isResult)
                {
                    if (isWin)
                    {
                        winPop.SetActive(true);
                        blur.GetComponent<Blur>().isBlur();
                    }
                    else
                    {
                        losePop.SetActive(true);
                        blur.GetComponent<Blur>().isBlur();
                    }
                    isResult = false;
                }
            }
        }

    }

    public void IsSlow()
    {
        if (isSlow)
        {
            Time.timeScale = 0.001f;
            isSlow = false;
        }
        else
        {
            isSlow = true;
        }
    }

    public void IsResult(bool _isWin)
    {
        timeScale = 0.001f;
        count = 0;
        isSlow = false;
        isResult = true;
        isWin = _isWin;
    }
}
