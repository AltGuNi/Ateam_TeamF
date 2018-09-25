using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
 
//angleのスピードで、とあるオブジェクトの周りを回転するスクリプト
public class Scroll_Menu : MonoBehaviour {
 
 
	public int i = 0;

	private Vector3[] menu_pos = {
		new Vector3(-1.77f, 2.11f, 3.0f),
		new Vector3(-1.13f, 1.5f, 2.0f),
		new Vector3(-0.53f, 0.9f, 1.0f),
		new Vector3(0.04f, -0.04f, 0.0f),
		new Vector3(-0.45f, -0.92f, 1.0f),
		new Vector3(-1.12f, -1.53f, 2.0f),
		new Vector3(-1.76f, -2.06f, 3.0f),
	};

	private float[] dark_level = {
		0.3f,
		0.2f,
		0.1f,
		0.0f,
		0.1f,
		0.2f,
		0.3f
	};

	private float startTime;
	private Vector3 startPosition;
	public float time = 0.5f;
	public GameObject dark;


	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(-2.0f, -2.0f, 0.0f);
		startPosition = new Vector3(-2.0f, -2.0f, 0.0f);
		dark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, dark_level[i]);
	}

	public FlickGesture flickGesture;
	public TapGesture tapGestureUp;
	public TapGesture tapGestureDown;

    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
		tapGestureUp.Tapped += OnTapped;
		tapGestureDown.Tapped += OnTapped;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
		tapGestureUp.Tapped -= OnTapped;
		tapGestureDown.Tapped -= OnTapped;
    }

    private void OnFlicked( object sender, System.EventArgs e )
    {
        // Debug.Log( "フリックされた: " + flickGesture.ScreenFlickVector );
		if(flickGesture.ScreenFlickVector.y < 0){
			i++;
			if(i >= 7) i = 0;
		}else{
			i--;
			if(i < 0) i = 6;
		}

		this.transform.position = new Vector3(this.transform.position.x, transform.position.y, menu_pos[i].z);
		dark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, dark_level[i]);
		startTime = Time.timeSinceLevelLoad;
		startPosition = this.transform.position;
    }


    private void OnTapped( object sender, EventArgs e )
    {
        if(sender == tapGestureDown){
			i++;
			if(i >= 7) i = 0;
		}else{
			i--;
			if(i < 0) i = 6;
		}

		this.transform.position = new Vector3(this.transform.position.x, transform.position.y, menu_pos[i].z);
		dark.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, dark_level[i]);
		startTime = Time.timeSinceLevelLoad;
		startPosition = this.transform.position;
    }

	void Update () {

		// if(i == 2){
		// 	this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		// }else{
		// 	this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		// }

		var diff = Time.timeSinceLevelLoad - startTime;
		if (diff > time) {
			transform.position = menu_pos[i];
		}

		var rate = diff / time;
		
		transform.position = Vector3.Lerp (startPosition, menu_pos[i], rate);


		// if(Input.GetKeyDown("up")){
		// 	i++;
		// 	if(i >= 4) i = 0;

		// 	this.transform.position = new Vector3(this.transform.position.x, transform.position.y, menu_pos[i].z);

		// 	startTime = Time.timeSinceLevelLoad;
		// 	startPosition = this.transform.position;
		// }
	}
}