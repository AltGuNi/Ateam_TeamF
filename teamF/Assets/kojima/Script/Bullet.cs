using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BeseObject {

    float count = 0.0f;
    [HideInInspector]
    public Vector2 velocity = Vector2.zero;
    Rigidbody2D rigid2D;
	// Use this for initialization
	void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (status.attackType)
        {
            case AttackType.StopNomal:
                count += Time.deltaTime;
                if (count >= 1.0f)
                {
                    rigid2D.velocity = velocity;
                }
                break;
            default:
                rigid2D.velocity = velocity;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Bullet")
        {
            return;
        }
        BeseObject baseObject = collide.gameObject.GetComponent<BeseObject>();
        if (baseObject)
        {
            if (BeseObject.CollideType.Neutral == baseObject.colideType)
            {
                baseObject.BeDamaged(status);

                GameObject.Find("HitEffectManager").GetComponent<HitEffectManager>().HitEffectPlay(transform.position);
                Destroy(this.gameObject);
            }
            else if (colideType != baseObject.colideType &&
                BeseObject.CollideType.None != baseObject.colideType)
            {
                baseObject.BeDamaged(status);

                GameObject.Find("HitEffectManager").GetComponent<HitEffectManager>().HitEffectPlay(transform.position);
                Destroy(this.gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    public void Destroy()
    {
        GameObject.Find("HitEffectManager").GetComponent<HitEffectManager>().HitEffectPlay(transform.position);
        Destroy(this.gameObject);
    }
}
