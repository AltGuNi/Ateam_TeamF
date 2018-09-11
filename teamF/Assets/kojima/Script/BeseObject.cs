using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeseObject : MonoBehaviour {
    public enum TypeData
    {
        None,
        Player,
        Enemy,

        TypeMax
    };
    public enum AttributeData
    {
        Nomal,
        Fire,
        Water,
        Wood,

        AttributeMax
    };

    [SerializeField]
    TypeData type = TypeData.None;
    [SerializeField]
    AttributeData attribute = AttributeData.Nomal;
    [SerializeField]
    float HP = 0.0f;
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

    public TypeData Type
    {
        get { return type; }
        set { type = value; }
    }
    public AttributeData Attribute
    {
        get { return attribute; }
        set { attribute = value; }
    }
}
