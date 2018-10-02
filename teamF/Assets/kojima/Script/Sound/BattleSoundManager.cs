using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSoundManager : MonoBehaviour {

    public enum Type
    {
        BattleBGM,
        PlaySkill,
        NormalBullet,
        FireBullet,
        WaterBullet,
        WoodBullet,
        BulletHit,
        ChangeElement,
        GameClear,
        GameOver,

        Max
    }

    // 値のある基本ステータス
    [System.Serializable]
    public class Sound
    {
        public string name;
        public Type type;
        public AudioClip sound;
        [Range(0.0f, 1.0f)]
        public float volume = 1.0f;
        public AudioSource audioSource;
    };

    public Sound[] sound = new Sound[(int)Type.Max];

    // Use this for initialization
    void Start () {
        PlaySound(Type.BattleBGM);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(Type type)
    {
        if (sound[(int)type].audioSource &&
            sound[(int)type].sound)
        {
            sound[(int)type].audioSource.volume = sound[(int)type].volume;
            sound[(int)type].audioSource.PlayOneShot(sound[(int)type].sound);
        }
    }
}
