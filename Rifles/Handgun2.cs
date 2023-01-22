using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun2 : MonoBehaviour
{
    [Header("Rifle things")]
    public new Camera camera;
    public float giveDamage = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 10f;
    private float nextTimeToShoot = 0f;
    public Transform hand;
    public bool isMoving;

    [Header("Rifle Ammunition")]
    private int maximumAmmunition = 25;
    public int mag = 10;
    private int presentAmmunition;
    public float reloadingTime = 4.3f;
    private bool setReloading = false;

    [Header("Rifle Effect")]
    public ParticleSystem muzzleSpark;
    public ParticleSystem metalEffect;

    [Header("Sounds and UI")]
    public GameObject ammoOutUI;


    private void Awake() {
        transform.SetParent(hand);
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmunition = maximumAmmunition;
    }

    void Update() {
        if(setReloading) {
            return;
        }

        if(presentAmmunition <= 0) {
            StartCoroutine(Reload());
            return;
        }
        if(isMoving == false) {
            if(Input.GetButton("Fire1") && Time.time >= nextTimeToShoot) {
                nextTimeToShoot = Time.time + 1f/fireCharge;
                Shoot();
            }
        }       
    }

    void Shoot() {
        if(mag == 0) {
            StartCoroutine(ShowAmmoOut());
            return;
        }
        presentAmmunition--;
        if(presentAmmunition == 0) {
            mag--;
        }
        muzzleSpark.Play();
        RaycastHit hitInfo;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, shootingRange)) {
            Object obj = hitInfo.transform.GetComponent<Object>();
            if(obj != null) {
                obj.ObjectHitDamage(giveDamage);
                Instantiate(metalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }

    IEnumerator Reload() {
        setReloading = true;
        yield return new WaitForSeconds(reloadingTime);
        presentAmmunition = maximumAmmunition;
        setReloading = false;
    }

    IEnumerator ShowAmmoOut() {
        ammoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        ammoOutUI.SetActive(false);
    }
}
