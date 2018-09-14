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

    [System.Serializable]
    public class Status
    {
        public TypeData type = TypeData.None;
        public AttributeData attribute = AttributeData.Nomal;
        public float HP = 0.0f;
        public float attack = 0.0f;
        public float defence = 0.0f;
    }

    public Status status;
}
