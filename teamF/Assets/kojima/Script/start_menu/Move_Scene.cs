using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;
using UnityEngine.SceneManagement;

public class Move_Scene : MonoBehaviour {

	public string move_scene = "main_menu";
    public TapGesture tapGesture;

	public AudioClip audio;
	private AudioSource audioSource;

	void Start(){
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

    // private void OnEnable()
    // {
    //     GetComponent<PressGesture>().Pressed += OnPressed;
    // }

    // private void OnDisable()
    // {
    //     GetComponent<PressGesture>().Pressed -= OnPressed;
    // }

    // private void OnPressed(object sender, EventArgs e)
    // {
    //     SceneManager.LoadScene(move_scene);
    // }

    private void OnEnable()
    {
        tapGesture.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        tapGesture.Tapped -= OnTapped;
    }

    private void OnTapped( object sender, EventArgs e )
    {
				audioSource.PlayOneShot (audio);
				StartCoroutine(DelayMethod(30, () =>
    	{
        SceneManager.LoadScene(move_scene);
    	}));

    }
		private IEnumerator DelayMethod(int delayFrameCount, Action action)
		{
    		for (var i = 0; i < delayFrameCount; i++)
    		{
        		yield return null;
    		}
    		action();
		}

}
