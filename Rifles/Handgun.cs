using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 1.9f;
    public float playerSprint = 4f;

    [Header("Player Animator and Gravity")]
    public CharacterController CC;
    public float gravity = -9.81f;
    public Animator animator;

    [Header("Player Script Camera")]
    public Transform playerCamera;

    [Header("Player jumping and velocity")]
    public float jumpRange = 1f;
    public float turnCalmTime = 0.1f;
    float turnCalmVelocity;
    Vector3 velocity;
    public Transform surfaceCheck;
    bool onSurface;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;




    [Header("Rifle things")]
    public new Camera camera;
    public float giveDamage = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 4f;
    private float nextTimeToShoot = 0f;
    public Transform hand;
    public Transform PlayerTransform;
    public bool isMoving;
    public Handgun2 handgun2;

    [Header("Rifle Ammunition")]
    private int maximumAmmunition = 25;
    public int mag = 10;
    private int presentAmmunition;
    public float reloadingTime = 4.3f;
    private bool setReloading = false;

    [Header("Rifle Effect")]
    public ParticleSystem muzzleSpark;
    public ParticleSystem metalEffect;
    public ParticleSystem goreEffect;

    [Header("Sounds and UI")]
    public GameObject ammoOutUI;
    bool HandgunActive = true;

    private void Awake() {
        transform.SetParent(hand);
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmunition = maximumAmmunition;
    }

    void Update() {

        if(HandgunActive == true) {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("GunAnimator");
        }
        onSurface = Physics.CheckSphere(surfaceCheck.position, surfaceDistance, surfaceMask);
        if(onSurface && velocity.y < 0) {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        CC.Move(velocity * Time.deltaTime);
        playerMove();
        Jump();
        Sprint();


        if(setReloading) {
            return;
        }

        if(presentAmmunition <= 0) {
            StartCoroutine(Reload());
            return;
        }

        if(isMoving == false) {
            if(Input.GetButton("Fire1") && Time.time >= nextTimeToShoot) {
                animator.SetBool("Shoot", true);
                nextTimeToShoot = Time.time + 1f/fireCharge;
                Shoot();
            } 
            else {
                animator.SetBool("Shoot", false);
            } 
        }
          
    }

    void playerMove() {
        float horizontal_axis = Input.GetAxisRaw("Horizontal");
        float vertical_axis = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;
        if(direction.magnitude >= 0.1f) {
            animator.SetBool("WalkForward", true);
            animator.SetBool("RunForward", false);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(PlayerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);

            PlayerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            CC.Move(moveDirection.normalized * playerSpeed * Time.deltaTime);
            jumpRange = 0f;
            isMoving = true;
            handgun2.isMoving = true;
        } 
        else {    
            animator.SetBool("WalkForward", false);
            animator.SetBool("RunForward", false);
            jumpRange = 1f;
            isMoving = false;
            handgun2.isMoving = false;
        }
    }

    void Jump() {
        if(Input.GetButtonDown("Jump") && onSurface) {
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
        }
        else {
            animator.SetBool("IdleAim", true);
            animator.ResetTrigger("Jump");
        }
    }

    void Sprint() {
        if((Input.GetButton("Sprint") && Input.GetKey(KeyCode.UpArrow) && onSurface) || (Input.GetButton("Sprint") && Input.GetKey(KeyCode.W) && onSurface)) {
            float horizontal_axis = Input.GetAxisRaw("Horizontal");
            float vertical_axis = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal_axis, 0f, vertical_axis).normalized;
            if(direction.magnitude >= 0.1f) {
                animator.SetBool("WalkForward", false);
                animator.SetBool("RunForward", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(PlayerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);

                PlayerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                CC.Move(moveDirection.normalized * playerSprint * Time.deltaTime);
                jumpRange = 0f;
                isMoving = true;
                handgun2.isMoving = true;
            } 
            else {
                animator.SetBool("WalkForward", true);
                animator.SetBool("RunForward", false);
                jumpRange = 1f;
                isMoving = false;
                handgun2.isMoving = false;
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
        AmmoCount.instance.UpdateAmmoText(presentAmmunition);
        AmmoCount.instance.UpdateMagText(mag);
        muzzleSpark.Play();
        RaycastHit hitInfo;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, shootingRange)) {
            Object obj = hitInfo.transform.GetComponent<Object>();
            PoliceOfficer policeOfficer = hitInfo.transform.GetComponent<PoliceOfficer>();
            Police2Officer police2Officer = hitInfo.transform.GetComponent<Police2Officer>();
            Gangster1 gs1 = hitInfo.transform.GetComponent<Gangster1>();
            CharacterNavigatorScript cns = hitInfo.transform.GetComponent<CharacterNavigatorScript>();
            BossScript bs = hitInfo.transform.GetComponent<BossScript>();

            if(obj != null) {
                obj.ObjectHitDamage(giveDamage);
                Instantiate(metalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else if(policeOfficer != null) {
                policeOfficer.characterHitDamage(giveDamage);
                Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else if(police2Officer != null) {
                police2Officer.characterHitDamage(giveDamage);
                Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else if(gs1 != null) {
                gs1.characterHitDamage(giveDamage);
                Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else if(cns != null) {
                cns.characterHitDamage(giveDamage);
                Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
            else if(bs != null) {
                bs.characterHitDamage(giveDamage);
                Instantiate(goreEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }

    IEnumerator Reload() {
        playerSpeed = 0f;
        playerSprint = 0f;
        setReloading = true;
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(reloadingTime);
        animator.SetBool("Reload", false);
        presentAmmunition = maximumAmmunition;
        playerSpeed = 1.5f;
        playerSprint = 4f;
        setReloading = false;
    }

    IEnumerator ShowAmmoOut() {
        ammoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        ammoOutUI.SetActive(false);
    }
}
