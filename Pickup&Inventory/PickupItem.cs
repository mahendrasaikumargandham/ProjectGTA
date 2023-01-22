using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("Item Info")]
    public int itemPrice;
    public int itemRadius;
    public string itemTag;
    private GameObject itemToPick;

    [Header("Player Info")]
    public Player player;
    public Inventory inventory;
    public Missions missions;


    private void Start() {
        itemToPick = GameObject.FindWithTag(itemTag);
    }

    private void Update() {
        if(Vector3.Distance(transform.position, player.transform.position) < itemRadius) {
            if(Input.GetKeyDown("f")) {
                if(itemPrice > player.playerMoney) {
                }
                else {
                    if(missions.Mission1 == true && missions.Mission2 == true && missions.Mission4 == false) {
                        missions.Mission3 = true;
                        player.playerMoney += 800;
                    }
                    if(itemTag == "HandGunPickup") {
                        player.playerMoney -= itemPrice;
                        inventory.weapon1.SetActive(true);
                        inventory.isWeapon1Picked = true;
                    }
                    else if(itemTag == "ShotGunPickup") {
                        player.playerMoney -= itemPrice;
                        inventory.weapon2.SetActive(true);
                        inventory.isWeapon2Picked = true;
                    }
                    else if(itemTag == "UZIPickup") {
                        player.playerMoney -= itemPrice;
                        inventory.weapon3.SetActive(true);
                        inventory.isWeapon3Picked = true; 
                    }
                    else if(itemTag == "BazookaPickup") {
                        player.playerMoney -= itemPrice;
                        inventory.weapon4.SetActive(true);
                        inventory.isWeapon4Picked = true; 
                    }
                    itemToPick.SetActive(false);
                }
            } 
        }
    }
}
