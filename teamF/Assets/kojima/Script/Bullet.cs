using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnBecameInvisible()
    {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }

    public Vector2 Velocity
    {
        get { var vel = GetComponent<Rigidbody2D>().velocity; return vel; }
        set { GetComponent<Rigidbody2D>().velocity = value; }
    }
}
