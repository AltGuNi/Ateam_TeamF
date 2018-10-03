using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Soundmain : MonoBehaviour {
    public bool DontDestroyEnabled = true;

    AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
       
        if (DontDestroyEnabled) {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this);
        }
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name != "test")
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }
    }
}
