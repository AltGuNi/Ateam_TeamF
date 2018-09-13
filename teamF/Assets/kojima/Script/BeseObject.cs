using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    
    public TypeData type = TypeData.None;
    public AttributeData attribute = AttributeData.Nomal;
    public float HP = 0.0f;
    public float attack = 0.0f;
    public float defence = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

// インスペクタの拡張
[CanEditMultipleObjects]
[CustomEditor(typeof(BeseObject), true)]
public class BeseObjectInspector : Editor
{
    bool showPosition = false;
    Player character = null;

    void OnEnable()
    {
        //Character コンポーネントを取得
        character = (Player)target;
    }

    public override void OnInspectorGUI()
    {
        showPosition = EditorGUILayout.Foldout(showPosition, "ステータス");
        
        if (showPosition)
        {
            base.OnInspectorGUI();
            //character.type = (BeseObject.TypeData)EditorGUILayout.EnumPopup("オブジェクトの種類", character.type);
        }
    }
}
