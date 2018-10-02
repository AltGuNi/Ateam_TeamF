using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour {

    public ParticleSystem skillEffect;              // スキルエフェクト
    BattleSoundManager battleSoundManager;
    // Use this for initialization
    void Start ()
    {
        battleSoundManager = GameObject.Find("BattleSoundManager").GetComponent<BattleSoundManager>();
    }

	// Update is called once per frame
	void Update () {

	}

    public void SkillEffectPlay()
    {
        skillEffect.Emit(1);
        battleSoundManager.PlaySound(BattleSoundManager.Type.PlaySkill, true);
    }
}
