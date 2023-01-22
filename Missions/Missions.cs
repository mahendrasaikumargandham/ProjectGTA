using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public bool Mission1 = false;
    public bool Mission2 = false;
    public bool Mission3 = false;
    public bool Mission4 = false;

    public Text missionText;

    private void Update() {
        if(Mission1 == false &&  Mission2 == false && Mission3 == false && Mission4 == false) {
            missionText.text = "Locate your house & save the game";
        }
        if(Mission1 == true &&  Mission2 == false && Mission3 == false && Mission4 == false) {
            missionText.text = "Meet frank in the Police Station";
        }
        if(Mission1 == true &&  Mission2 == true && Mission3 == false && Mission4 == false) {
            missionText.text = "Find Weapons at home";
        }
        if(Mission1 == true &&  Mission2 == true && Mission3 == true && Mission4 == false) {
            missionText.text = "Find Villian and take revenge";
        }
        if(Mission1 == true &&  Mission2 == true && Mission3 == true && Mission4 == true) {
            missionText.text = "All missions completed!";
        }
    }
}
