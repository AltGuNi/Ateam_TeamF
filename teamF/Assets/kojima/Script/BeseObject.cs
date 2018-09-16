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
    public enum Elements
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

    // 値のある基本ステータス
    [System.Serializable]
    public struct ValueStatus
    {
        public float HP;                // 体力
        public float attack;            // 攻撃
        public float defence ;          // 防御
        public float bounceSpeed;       // 弾速
        public float duration;          // 発射間隔
    };

    // スキルのステータス
    [System.Serializable]
    public class SkillStatus
    {
        public float timeToActivate;    // スキルの発動可能までの時間
        public float timeToFinish;      // スキルの終了までの時間
        public float UpATK = 0.0f;
    };

    [System.Serializable]
    public class Status
    {
        string objectId;
        string name;
        public Elements bulletElement = Elements.Nomal;         // 弾の属性
        public Elements SpecialtyElement = Elements.Nomal;      // 現在の属性
        public AttackType attackType = AttackType.Nomal;        // 攻撃の種類
        public ValueStatus valueStatus = new ValueStatus();     // 値のステータス
        public SkillStatus skillStatus = new SkillStatus();     // スキルステータス
    }
    public CollideType colideType = CollideType.None;
    public Status status;

    public void BeDamaged(float value)
    {
        status.valueStatus.HP -= value;
        if (status.valueStatus.HP <= 0.0f)
        {
            status.valueStatus.HP = 0.0f;
        }
    }
}
