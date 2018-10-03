using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class flash_Button : MonoBehaviour {
    float a_color;
    bool flag_G;
	public GameObject dark;
	float dark_dist = 0;
    // Use this for initialization
    void Start () {
        a_color = 0;
    }
    // Update is called once per frame
    void Update () {
            //テキストの透明度を変更する
			if(a_color > 0){
				dark.GetComponent<SpriteRenderer>().color  += new Color(0.0f, 0.0f, 0.0f, dark_dist);
			}

			if (flag_G) {
                a_color -= Time.deltaTime;
				dark_dist = Time.deltaTime;
			}else{
                a_color += Time.deltaTime;
				dark_dist = -Time.deltaTime;
			}

            if (a_color < -0.8) {
                a_color = 0;
                flag_G = false;
            }else if(a_color > 1){
                a_color = 1;
                flag_G = true;
            }
    }
}