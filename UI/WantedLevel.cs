using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WantedLevel : MonoBehaviour
{
    public Player player;
    public GameObject level1Star;
    public bool level1 = false;
    public GameObject level2Star;
    public bool level2 = false;
    public GameObject level3Star;
    public bool level3 = false;
    public GameObject level4Star;
    public bool level4 = false;
    public GameObject level5Star;
    public bool level5 = false;

    private void Update() {
        if(player.currentKills == 1) {
            level1Star.SetActive(true);
            level1 = true;
        }
        if(player.currentKills >= 3) {
            level2Star.SetActive(true);
            level2 = true;
        }
        if(player.currentKills >= 6) {
            level3Star.SetActive(true);
            level3 = true;
        }
        if(player.currentKills >= 10) {
            level4Star.SetActive(true);
            level4 = true;
        }
        if(player.currentKills >= 12) {
            level5Star.SetActive(true);
            level5 = true;
        }
    }
}
