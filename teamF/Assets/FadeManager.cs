using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour {
    public GameObject Panel;
    float a;
		public AudioClip audio;
		private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
        a = Panel.GetComponent<SpriteRenderer>().color.a;
	}

//Aキーを押されたらフェード開始
	void Update () {
        　
            StartCoroutine(FadePanel());
						SceneManager.LoadScene ("Start");
						audioSource.PlayOneShot (audio);
	}

//フェードアウト自体は↓の処理
    IEnumerator FadePanel()
    {
        while(a < 10)
        {
            Panel.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.01f);
            a += 0.01f;
            yield return null;
        }
    }
}
