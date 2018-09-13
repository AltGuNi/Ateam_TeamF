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

    void OnTriggerEnter2D(Collider2D collide)
    {
        switch (collide.gameObject.tag)
        {
            case "Enemy":
                if(status.type != collide.gameObject.GetComponent<Enemy>().status.type)
                {
                    Destroy(this.gameObject);
                }
                break;
            case "Player":
                if (status.type != collide.gameObject.GetComponent<Character>().status.type)
                {
                    Destroy(this.gameObject);
                }
                break;
        }
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
