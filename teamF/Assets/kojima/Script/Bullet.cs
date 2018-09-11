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
                if(Type != collide.gameObject.GetComponent<Enemy>().Type)
                {
                    Destroy(this.gameObject);
                }
                break;
            case "Player":
                if (Type != collide.gameObject.GetComponent<Player>().Type)
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
