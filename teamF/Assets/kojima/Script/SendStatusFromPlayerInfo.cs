using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendStatusFromPlayerInfo : MonoBehaviour {

    public Character player;

    PlayerInfo playerInfo;

    BeseObject.Status status = new BeseObject.Status();

    // Use this for initialization
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        for (int i = 0; i < (int)PlayerInfo.CharaNum.Max; i++)
        {
            if (playerInfo.chara[i])
            {
                status.valueStatus.attack += playerInfo.chara[i].status.valueStatus.attack;
                status.valueStatus.bounceSpeed += playerInfo.chara[i].status.valueStatus.bounceSpeed;
                status.valueStatus.duration += playerInfo.chara[i].status.valueStatus.duration;
            }
        }
        player.status.valueStatus = status.valueStatus;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
