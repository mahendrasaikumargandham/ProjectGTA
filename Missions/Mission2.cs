using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
    public Player player;
    public Missions missions;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            if(missions.Mission1 == true && missions.Mission3 == false && missions.Mission4 == false) {
                missions.Mission2 = true;
                player.playerMoney += 600;
            }
        }
    }
}
