using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour {

    public ParticleSystem skillEffect;              // スキルエフェクト

                                                    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SkillEffectPlay()
    {
        skillEffect.Emit(1);
    }
}
