using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerMoney;
    public float[] position;
    public bool isWeapon1Picked;
    public bool isWeapon2Picked;
    public bool isWeapon3Picked;
    public bool isWeapon4Picked;
    public bool Mission1;
    public bool Mission2;
    public bool Mission3;
    public bool Mission4;

    public PlayerData(Player player) {
        playerMoney = player.playerMoney;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        isWeapon1Picked = player.inventory.isWeapon1Picked;
        isWeapon2Picked = player.inventory.isWeapon2Picked;
        isWeapon3Picked = player.inventory.isWeapon3Picked;
        isWeapon4Picked = player.inventory.isWeapon4Picked;

        Mission1 = player.missions.Mission1;
        Mission2 = player.missions.Mission2;
        Mission3 = player.missions.Mission3;
        Mission4 = player.missions.Mission4;
    }
}
