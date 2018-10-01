using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIconEffectManager : MonoBehaviour {

    public ParticleSystem skillIconEffect;          // スキルアイコンのエフェクト
    public ParticleSystem skillIconBigEffect;

                                                    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SkillIconEffectPlay(Vector3 pos)
    {
        skillIconEffect.transform.position = pos + Camera.main.transform.forward * 10;
        skillIconEffect.Emit(1);
    }

    public void SkillIconBigEffectPlay(Vector3 pos)
    {
        skillIconBigEffect.transform.position = pos + Camera.main.transform.forward * 10;
        skillIconBigEffect.Emit(1);
    }
}
