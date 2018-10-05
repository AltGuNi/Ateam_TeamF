using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
# endif
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
        None,
        Nomal,
        Fire,
        Wood,
        Water,

        Max
    };

    public enum AttackType
    {
        Nomal,
        TwoWay,
        StopNomal,

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

        public ValueStatus Clone()
        {
            ValueStatus clone = new ValueStatus();
            clone.HP = this.HP;
            clone.attack = this.attack;
            clone.defence = this.defence;
            clone.bounceSpeed = this.bounceSpeed;
            clone.duration = this.duration;
            return clone;
        }
    };

    // 倍率の最高値
    public const float MAG_MAX = 5.0f;
    public const float MAG_MIN = 0.1f;
    // スキルのステータス
    [System.Serializable]
    public class SkillStatus
    {
        public float timeToActivate;    // スキルの発動可能までの時間
        public float timeToFinish;      // スキルの終了までの時間
        public float UpATK = 0.0f;      // 攻撃力向上値
        public float CureHP = 0.0f;     // 回復量
        public float UpBounceSpeed = 0.0f;      // 弾速向上値
        public float DownDuration = 0.0f;       // 間隔の低下値
        public Elements ChangeElement = Elements.Max; // 属性変更

        [SerializeField, Space(10)]
        [Range(MAG_MIN, MAG_MAX)]
        public float MAG_ATK = 1.0f;            // 攻撃力倍率値
        [Range(MAG_MIN, MAG_MAX)]
        public float MAG_BounceSpeed = 1.0f;     // 弾速倍率値
        [Range(MAG_MIN, MAG_MAX)]
        public float MAG_Duration = 1.0f;       // 間隔の倍率値 

        public void Add(SkillStatus b)
        {
            UpATK += b.UpATK;
            CureHP += b.CureHP;
            UpBounceSpeed += b.UpBounceSpeed;
            DownDuration += b.DownDuration;

            MAG_ATK *= b.MAG_ATK;
            MAG_BounceSpeed *= b.MAG_BounceSpeed;
            MAG_Duration *= b.MAG_Duration;
        }

        public void Remove(SkillStatus b)
        {
            UpATK -= b.UpATK;
            CureHP -= b.CureHP;
            UpBounceSpeed -= b.UpBounceSpeed;
            DownDuration -= b.DownDuration;

            MAG_ATK /= b.MAG_ATK;
            MAG_BounceSpeed /= b.MAG_BounceSpeed;
            MAG_Duration /= b.MAG_Duration;
        }

        public SkillStatus Clone()
        {
            SkillStatus clone = new SkillStatus();
            clone.timeToActivate = this.timeToActivate;    
            clone.timeToFinish = this.timeToFinish;      
            clone.UpATK = this.UpATK;      
            clone.CureHP = this.CureHP;                             
            clone.UpBounceSpeed = this.UpBounceSpeed;      
            clone.DownDuration = this.DownDuration;
            clone.ChangeElement = this.ChangeElement;
            clone.MAG_ATK = this.MAG_ATK;            
            clone.MAG_BounceSpeed = this.MAG_BounceSpeed;
            clone.MAG_Duration = this.DownDuration;
            return clone;    
        }
    };

    [System.Serializable]
    public class Status
    {
        string objectId;
        string name;
        public Elements bulletElement = Elements.Nomal;         // 弾の属性
        public Elements specialtyElement = Elements.Max;        // 得意な属性
        public AttackType attackType = AttackType.Nomal;        // 攻撃の種類
        public ValueStatus valueStatus = new ValueStatus();     // 値のステータス
        public SkillStatus skillStatus;     // スキルステータス
#if UNITY_EDITOR
        [ReadOnly]
#endif
        public SkillStatus upSkillStatus;    // スキル向上値ステータス

        public Status Clone()
        {
            Status clone = new Status();
            clone.objectId = this.objectId;
            clone.name = this.name;
            clone.bulletElement = this.bulletElement;
            clone.specialtyElement = this.specialtyElement;
            clone.attackType = this.attackType;
            clone.valueStatus = this.valueStatus.Clone();
            clone.skillStatus = this.skillStatus.Clone();
            clone.upSkillStatus = this.upSkillStatus.Clone();

            return clone;
        }
    }

    public CollideType colideType = CollideType.None;
    public Status status;

    public void BeDamaged(Status enemy)
    {
        bool isDamage = false;
        float doubleValue = 1.0f;
        // 無属性(Normal)の場合
        if (enemy.bulletElement == Elements.Nomal)
        {
            isDamage = true;
            doubleValue = 1.5f;
        }
        else
        {
            // 弱点属性を求める
            int bufElement = (int)status.bulletElement - 1;
            if (bufElement <= (int)Elements.Nomal)
            {
                bufElement = (int)Elements.Max - 1;
            }
            // 弱点属性の処理
            if ((int)enemy.bulletElement == bufElement)
            {
                isDamage = true;
                doubleValue = 1.5f;
                Debug.Log("weak");
            }
            else
            {
                // 無効属性を求める
                bufElement = (int)status.bulletElement + 1;
                if (bufElement >= (int)Elements.Max)
                {
                    bufElement = (int)Elements.Fire;
                }
                // 無効属性の処理
                if ((int)enemy.bulletElement == bufElement)
                {

                }
                // それ以外
                else
                {
                    isDamage = true;
                    doubleValue = 1.0f;
                    Debug.Log("hit");
                }
            }
        }

        // 自分が無属性の場合は倍率を少なくする
        if(status.bulletElement == Elements.Nomal)
        {
            doubleValue *= 0.5f;
        }

        if (isDamage)
        {
            // 攻撃値を計算
            // 得意属性の場合1.5倍
            float atk = enemy.valueStatus.attack;
            if (enemy.bulletElement == enemy.specialtyElement)
            {
                atk *= 1.5f;
            }
            atk = (atk * enemy.upSkillStatus.MAG_ATK) + enemy.upSkillStatus.UpATK;
            // 防御値を計算
            float def = status.valueStatus.defence;
            // ダメージを計算
            float damage = atk - def;
            damage = (damage * doubleValue);

            // １ダメージ以上は与える
            if (damage <= 1.0f)
            {
                damage = 1.0f;
            }
            status.valueStatus.HP -= damage;
        }
        // HPを0以下にしない
        if (status.valueStatus.HP <= 0.0f)
        {
            status.valueStatus.HP = 0.0f;
        }
    }
}
#if UNITY_EDITOR
public class ReadOnlyAttribute : PropertyAttribute
{

}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
# endif
