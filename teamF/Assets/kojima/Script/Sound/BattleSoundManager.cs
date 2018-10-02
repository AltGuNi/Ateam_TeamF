using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSoundManager : MonoBehaviour
{

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
        Explosion,
        Up,

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
        public bool isTimeScale = false;
    };

    public Sound[] sound = new Sound[(int)Type.Max];
    public UnityEngine.Audio.AudioMixer mixer;

    // Use this for initialization
    void Start()
    {
        PlaySound(Type.BattleBGM, true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].isTimeScale)
            {
                sound[i].audioSource.pitch = Time.timeScale;
            }
        }
    }

    public void PlaySound(Type type, bool startVolume = false)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].type == type)
            {
                if (sound[i].audioSource &&
                    sound[i].sound)
                {
                    if (startVolume)
                    {
                        sound[i].audioSource.volume = sound[i].volume;
                    }
                    sound[i].audioSource.PlayOneShot(sound[i].sound);
                }
            }
        }
    }

    public void ChangePitchSound(Type type, float pitch)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].type == type)
            {
                if (sound[i].audioSource &&
                    sound[i].sound)
                {
                    sound[i].audioSource.pitch = pitch;
                }
            }
        }
    }

    public void StopSound(Type type)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if (sound[i].type == type)
            {
                if (sound[i].audioSource &&
                    sound[i].sound)
                {
                    sound[i].audioSource.Stop();
                }
            }
        }
    }
}
