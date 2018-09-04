using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BeseObject {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public Vector2 Velocity
    {
        get { var vel = GetComponent<Rigidbody2D>().velocity; return vel; }
        set { GetComponent<Rigidbody2D>().velocity = value; }
    }
}
