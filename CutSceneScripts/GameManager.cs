using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects1")]
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

    [Header("GameObjects2")]
    public GameObject cutSceneTimeline;
    public GameObject cutScenePlayer;
    public GameObject rebel1;
    public GameObject rebel2;
    public GameObject bus;
    public GameObject cutSceneCamera;
    public GameObject cutSceneEnder;

    public Player playerScript;
    
    private void Start() {
        if(MainMenu.instance.continueGame == true) {

            cutSceneTimeline.SetActive(false);
            cutScenePlayer.SetActive(false);
            rebel1.SetActive(false);
            rebel2.SetActive(false);
            bus.SetActive(false);
            cutSceneCamera.SetActive(false);
            cutSceneEnder.SetActive(false);

            playerScript.LoadPlayer();

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

        if(MainMenu.instance.startGame == true) {
            cutSceneTimeline.SetActive(true);
            cutScenePlayer.SetActive(true);
            rebel1.SetActive(true);
            rebel2.SetActive(true);
            bus.SetActive(true);
            cutSceneCamera.SetActive(true);
            cutSceneEnder.SetActive(true);

            player.SetActive(false);
            playerCamera.SetActive(false);
            tpCineMachine.SetActive(false);
            // playerVehicle.SetActive(false);
            crossHair.SetActive(false);
            playerUI.SetActive(false);
            gangsters.SetActive(false);
            AICharacters.SetActive(false);
            policeOfficers.SetActive(false);
            miniMapCam.SetActive(false);
            miniMapCanvas.SetActive(false);
            saveCanvas.SetActive(false);
            ps1.GetComponent<PoliceSpawner>().enabled = false;
            ps2.GetComponent<Police2Spawner>().enabled = false;
        }
    }
}
