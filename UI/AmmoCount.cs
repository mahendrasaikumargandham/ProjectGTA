using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammoText;
    public Text magText;

    public static AmmoCount instance;

    private void Awake() {
        instance = this;
    }

    public void UpdateAmmoText(int presentAmmunition) {
        ammoText.text = "" + presentAmmunition;
    }

    public void UpdateMagText(int presentMag) {
        magText.text = "" + presentMag;
    }
}
