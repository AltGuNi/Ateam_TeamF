using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeseObject : MonoBehaviour {
    public enum AttributeData
    {
        Nomal,
        Fire,
        Water
    };

    [SerializeField]
    AttributeData attribute;
    [SerializeField]
    float attack = 0.0f;
    [SerializeField]
    float defence = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public AttributeData Attribute
    {
        get { return attribute; }
    }
}
