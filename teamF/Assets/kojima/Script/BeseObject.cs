using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeseObject : MonoBehaviour {
    public enum CollideType
    {
        None,       // 当たらない
        Player,     // プレイヤー
        Enemy,      // 敵
        Neutral,    // すべて

        Max
    };
    public enum AttributeData
    {
        Nomal,
        Fire,
        Water,
        Wood,

        Max
    };

    public enum AttackType
    {
        Nomal,
        TwoWay,

        Max
    };

    [System.Serializable]
    public class Status
    {
        string objectId;
        string name;
        public AttributeData bulletAttribute = AttributeData.Nomal;     // 弾の属性
        public AttributeData attribute = AttributeData.Nomal;           // 現在の属性
        public AttackType attackType = AttackType.Nomal;                // 攻撃の種類
        public float HP = 0.0f;                 // 体力
        public float attack = 0.0f;             // 攻撃
        public float defence = 0.0f;            // 防御
        public float bounceSpeed = 0.0f;        // 弾速
    }
    public CollideType colideType = CollideType.None;
    public Status status;

    virtual public void Skill()
    {
    }
}
