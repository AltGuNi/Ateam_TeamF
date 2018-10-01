using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : MonoBehaviour {

    public ParticleSystem hitEffect;                // 衝突エフェクト
    public Camera _camera;                          // カメラの座標
    public int emitCount = 9;

    List<Vector3> poslist = new List<Vector3>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Vector3 pos in poslist)
        {
            hitEffect.transform.position = pos + _camera.transform.forward * 10;
            hitEffect.Emit(emitCount);
        }
        poslist.Clear();
	}

    public void HitEffectPlay(Vector3 pos)
    {
        poslist.Add(pos);
    }
}
