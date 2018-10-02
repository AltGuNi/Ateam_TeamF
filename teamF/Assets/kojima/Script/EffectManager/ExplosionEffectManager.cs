using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectManager : MonoBehaviour {

    public ParticleSystem explosionEffect;          // 爆発エフェクト
    public Camera _camera;                          // カメラの座標
    public int emitCount = 9;

    List<Vector3> poslist = new List<Vector3>();
    BattleSoundManager battleSoundManager;
    // Use this for initialization
    void Start () {

        battleSoundManager = GameObject.Find("BattleSoundManager").GetComponent<BattleSoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Vector3 pos in poslist)
        {
            explosionEffect.transform.position = pos + _camera.transform.forward * 10;
            explosionEffect.Emit(emitCount);

            battleSoundManager.PlaySound(BattleSoundManager.Type.Explosion, true);
        }
        poslist.Clear();
    }

    public void ExploisonEffectPlay(Vector3 pos)
    {
        poslist.Add(pos);
    }
}
