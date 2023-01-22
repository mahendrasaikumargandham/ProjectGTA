using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGlow : MonoBehaviour
{
    public Player player;
    public Missions missions;
    public GameObject saveUI;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player") {
            player.SavePlayer();
            StartCoroutine(ActivateSaveUI());
        }
        if(missions.Mission2 == false && missions.Mission3 == false && missions.Mission4 == false) {
            missions.Mission1 = true;
            player.playerMoney += 400;
        }
    }

    IEnumerator ActivateSaveUI() {
        saveUI.SetActive(true);
        yield return new WaitForSeconds(2);
        saveUI.SetActive(false);
    }
}
