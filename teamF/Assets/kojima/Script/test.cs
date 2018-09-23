using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    ParticleSystem particle;
	// Use this for initialization
	void Start () {
        particle = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            particle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Camera.main.transform.forward * 10;
            particle.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            particle.Emit(1);
        }
	}
}
