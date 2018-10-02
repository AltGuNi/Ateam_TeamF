using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num : MonoBehaviour {

    public Sprite num_0;
    public Sprite num_1;
    public Sprite num_2;
    public Sprite num_3;
    public Sprite num_4;
    public Sprite num_5;
    public Sprite num_6;
    public Sprite num_7;
    public Sprite num_8;
    public Sprite num_9;

    public int num;
    public bool isAll = false;

    List<Image> digitList = new List<Image>();

	// Use this for initialization
	void Start () {
        foreach (Transform obj in gameObject.transform)
        {
            digitList.Add(obj.GetComponent<Image>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        SetNumber(num.ToString());
	}

    public void SetNumber(string _num)
    {
        // なにもない場合はすべてを透明にする
        if (_num == "" && !isAll)
        {
            foreach (Image image in digitList)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
            }
            return;
        }

        int index = _num.Length - 1;

        // 桁数を超えていた場合はすべて9にする
        if (index >= (digitList.Count))
        {
            foreach(Image image in digitList)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
                image.sprite = CharaToSprite('9');
            }
            return;
        }

        // 一桁目から画像を差し替え
        foreach (Image image in digitList)
        {
            if (index >= 0)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
                image.sprite = CharaToSprite(_num[index]);
                index--;
            }
            else
            {
                if (!isAll)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
                }
                image.sprite = CharaToSprite('0');
            }
        }
    }

    Sprite CharaToSprite(char _num)
    {
        switch (_num)
        {
            case '0':
                return num_0;
            case '1':
                return num_1;
            case '2':
                return num_2;
            case '3':
                return num_3;
            case '4':
                return num_4;
            case '5':
                return num_5;
            case '6':
                return num_6;
            case '7':
                return num_7;
            case '8':
                return num_8;
            case '9':
                return num_9;
        }
        return null;
    }
}
