using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Money")]
    public int playerMoney;
    public int currentKills;

    [Header("Player Inventory")]
    public Inventory inventory;
    public Missions missions;

    private void Update() {
        if(Input.GetKeyDown("p")) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        playerMoney = data.playerMoney;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        inventory.isWeapon1Picked = data.isWeapon1Picked;
        inventory.isWeapon2Picked = data.isWeapon2Picked;
        inventory.isWeapon3Picked = data.isWeapon3Picked;
        inventory.isWeapon4Picked = data.isWeapon4Picked;

        missions.Mission1 = data.Mission1;
        missions.Mission2 = data.Mission2;
        missions.Mission3 = data.Mission3;
        missions.Mission4 = data.Mission4;
    }
}
