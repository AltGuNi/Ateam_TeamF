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
        if (collide.gameObject.tag == "Bullet")
        {
            return;
        }
        if (collide.gameObject.GetComponent<BeseObject>())
        {
            if (BeseObject.CollideType.Neutral == collide.gameObject.GetComponent<BeseObject>().colideType)
            {
                Destroy(this.gameObject);
            }
            else if (colideType != collide.gameObject.GetComponent<BeseObject>().colideType &&
                BeseObject.CollideType.None != collide.gameObject.GetComponent<BeseObject>().colideType)
            {
                Destroy(this.gameObject);
            }
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
