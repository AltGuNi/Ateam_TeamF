using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour {

    public ParticleSystem skillEffect;              // スキルエフェクト
    public AudioClip skill_audio;
  	private AudioSource audioSource;
                                                    // Use this for initialization
    void Start () {
		    audioSource = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

    public void SkillEffectPlay()
    {
        //skillEffect.Play();
        skillEffect.Emit(1);
        audioSource.PlayOneShot (skill_audio);
    }
}
