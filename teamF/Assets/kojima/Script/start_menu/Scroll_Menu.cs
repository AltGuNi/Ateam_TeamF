using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
 
//angleのスピードで、とあるオブジェクトの周りを回転するスクリプト
public class Scroll_Menu : MonoBehaviour {
 
 
	public int i = 0;

	private Vector3[] menu_pos = {
		new Vector3(-2.44f, 0.68f, 3.0f),
		new Vector3(-1.04f, -0.46f, 2.0f),
		new Vector3(-0.36f, -1.92f, 1.0f),
		new Vector3(-1.49f, -3.34f, 0.0f),
	};

	private float startTime;
	private Vector3 startPosition;
	public float time = 0.5f;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(-2.0f, -2.0f, 0.0f);
		startPosition = new Vector3(-2.0f, -2.0f, 0.0f);
	}

	public FlickGesture flickGesture;

    private void OnEnable()
    {
        flickGesture.Flicked += OnFlicked;
    }

    private void OnDisable()
    {
        flickGesture.Flicked -= OnFlicked;
    }

    private void OnFlicked( object sender, System.EventArgs e )
    {
        Debug.Log( "フリックされた: " + flickGesture.ScreenFlickVector );
		if(flickGesture.ScreenFlickVector.y < 0){
			i++;
			if(i >= 4) i = 0;
		}else{
			i--;
			if(i < 0) i = 3;
		}

		this.transform.position = new Vector3(this.transform.position.x, transform.position.y, menu_pos[i].z);

		startTime = Time.timeSinceLevelLoad;
		startPosition = this.transform.position;
    }

	void Update () {

		if(i == 2){
			this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		}else{
			this.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		}

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