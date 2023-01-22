using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnder : MonoBehaviour
{
    [Header("GameObjects to Activate")]
    public GameObject player;
    public GameObject playerCamera;
    public GameObject tpCineMachine;
    // public GameObject playerVehicle;
    public GameObject crossHair;
    public GameObject playerUI;
    public GameObject gangsters;
    public GameObject AICharacters;
    public GameObject policeOfficers;
    public GameObject miniMapCam;
    public GameObject miniMapCanvas;
    public GameObject saveCanvas;
    public PoliceSpawner ps1;
    public Police2Spawner ps2;

    [Header("GameObjects to deactivate")]
    public GameObject cutSceneTimeline;
    public GameObject cutScenePlayer;
    public GameObject rebel1;
    public GameObject rebel2;
    public GameObject bus;
    public GameObject cutSceneCamera;
    public GameObject cutSceneEnder;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "CutSceneCamera") {

            cutSceneTimeline.SetActive(false);
            cutScenePlayer.SetActive(false);
            rebel1.SetActive(false);
            rebel2.SetActive(false);
            bus.SetActive(false);
            cutSceneCamera.SetActive(false);
            cutSceneEnder.SetActive(false);


            player.SetActive(true);
            playerCamera.SetActive(true);
            tpCineMachine.SetActive(true);
            // playerVehicle.SetActive(true);
            crossHair.SetActive(true);
            playerUI.SetActive(true);
            gangsters.SetActive(true);
            AICharacters.SetActive(true);
            policeOfficers.SetActive(true);
            miniMapCam.SetActive(true);
            miniMapCanvas.SetActive(true);
            saveCanvas.SetActive(true);
            ps1.GetComponent<PoliceSpawner>().enabled = true;
            ps2.GetComponent<Police2Spawner>().enabled = true;
        }
    }
}
