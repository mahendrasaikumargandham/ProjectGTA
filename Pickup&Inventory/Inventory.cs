using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Header("Item slots")]
    public GameObject weapon1;
    public bool isWeapon1Picked = false;
    public bool isWeapon1Active = false;
    public GameObject weapon2;
    public bool isWeapon2Picked = false;
    public bool isWeapon2Active = false;
    public GameObject weapon3;
    public bool isWeapon3Picked = false;
    public bool isWeapon3Active = false;
    public GameObject weapon4;
    public bool isWeapon4Picked = false;
    public bool isWeapon4Active = false; 

    [Header("Weapons to use")]
    public GameObject HandGun1;
    public GameObject HandGun2;
    public GameObject ShotGun;
    public GameObject Uzi;
    public GameObject Uzi2;
    public GameObject Bazooka;

    [Header("Player Scripts")]
    public PlayerScript playerScript;
    public Shotgun shotGunScript;
    public Handgun handGunScript;
    public Handgun2 handgun2Script;
    public UZI uziScript;
    public UZI2 uzi2Script;
    public Bazooka bazookaScript;

    [Header("Inventory")]
    public GameObject inventoryCanvas;
    public bool isPause = false;
    public SwitchCamera switchCamera;
    public GameObject AimCam;
    public GameObject ThirdPersonCam;
    public GameObject resumeUI;

    private void Update() {
        if(Input.GetKeyDown("1") && isWeapon1Picked == true) {
            isWeapon1Active = true;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = false;
            isRifleActive();
        }
        else if(Input.GetKeyDown("2") && isWeapon2Picked == true) {
            isWeapon1Active = false;
            isWeapon2Active = true;
            isWeapon3Active = false;
            isWeapon4Active = false;
            isRifleActive();
        }
        else if(Input.GetKeyDown("3") && isWeapon3Picked == true) {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = true;
            isWeapon4Active = false;
            isRifleActive();
        }
        else if(Input.GetKeyDown("4") && isWeapon4Picked == true) {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = true;
            isRifleActive();
        }

        else if(Input.GetKeyDown("tab")) {
            if(isPause) {
                HideInventory();
            }
            else {
                if(isWeapon1Picked == true) {
                    weapon1.SetActive(true);
                }
                if(isWeapon2Picked == true) {
                    weapon2.SetActive(true);
                }
                if(isWeapon3Picked == true) {
                    weapon3.SetActive(true);
                }
                if(isWeapon4Picked == true) {
                    weapon4.SetActive(true);
                }
                ShowInventory();
            }
        }
    }

    void isRifleActive() {
        if(isWeapon1Active == true) {
            HandGun1.SetActive(true);
            HandGun2.SetActive(true);
            ShotGun.SetActive(false);
            Uzi.SetActive(false);
            Uzi2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotGunScript.GetComponent<Shotgun>().enabled = false;
            handGunScript.GetComponent<Handgun>().enabled = true;
            handgun2Script.GetComponent<Handgun2>().enabled = true;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazookaScript.GetComponent<Bazooka>().enabled = false;
        }
        else if(isWeapon2Active == true) {
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(true);
            Uzi.SetActive(false);
            Uzi2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotGunScript.GetComponent<Shotgun>().enabled = true;
            handGunScript.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazookaScript.GetComponent<Bazooka>().enabled = false;
        }
        else if(isWeapon3Active == true) {
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(false);
            Uzi.SetActive(true);
            Uzi2.SetActive(true);
            Bazooka.SetActive(false);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotGunScript.GetComponent<Shotgun>().enabled = false;
            handGunScript.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = true;
            uzi2Script.GetComponent<UZI2>().enabled = true;
            bazookaScript.GetComponent<Bazooka>().enabled = false;
        }
        else if(isWeapon4Active == true) {
            HandGun1.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(false);
            Uzi.SetActive(false);
            Uzi2.SetActive(false);
            Bazooka.SetActive(true);

            playerScript.GetComponent<PlayerScript>().enabled = false;
            shotGunScript.GetComponent<Shotgun>().enabled = false;
            handGunScript.GetComponent<Handgun>().enabled = false;
            handgun2Script.GetComponent<Handgun2>().enabled = false;
            uziScript.GetComponent<UZI>().enabled = false;
            uzi2Script.GetComponent<UZI2>().enabled = false;
            bazookaScript.GetComponent<Bazooka>().enabled = true;
        }
    }

    void ShowInventory() {
        switchCamera.GetComponent<SwitchCamera>().enabled = false;
        ThirdPersonCam.SetActive(false);
        AimCam.SetActive(false);
        inventoryCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    void HideInventory() {
        switchCamera.GetComponent<SwitchCamera>().enabled = true;
        ThirdPersonCam.SetActive(true);
        AimCam.SetActive(true);
        inventoryCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
}
