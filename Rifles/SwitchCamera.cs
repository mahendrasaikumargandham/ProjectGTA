using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [Header("Cameras to assign")]
    public GameObject aimCam;
    public GameObject thirdPersonCam;
    public Animator animator;


    private void Update() {
        if((Input.GetButton("Fire2") && Input.GetKey(KeyCode.W)) || (Input.GetButton("Fire2") && Input.GetKey(KeyCode.UpArrow))) {
            animator.SetBool("AimWalk", true);
            animator.SetBool("ShootAim", false);
            thirdPersonCam.SetActive(false);
            aimCam.SetActive(true);
        } 
        else if(Input.GetButton("Fire2")) {
            animator.SetBool("ShootAim", true);
            animator.SetBool("AimWalk", true);

            thirdPersonCam.SetActive(false);
            aimCam.SetActive(true);
        }
        else {
            animator.SetBool("AimWalk", false);
            animator.SetBool("ShootAim", false);
            thirdPersonCam.SetActive(true);
            aimCam.SetActive(false);
        }
    }
}
