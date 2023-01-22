using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangster1 : MonoBehaviour
{
    [Header("Character Info")]
    public float movingSpeed;
    public float runningSpeed;
    private float currentMovingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;
    private float characterHealth = 120f;
    public float presentHealth;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;
    public Animator animator;

    [Header("Gangster AI")]
    public GameObject playerBody;
    public LayerMask layerMask;
    public float visionRadius;
    public float shootingRadius;
    public bool playerInVisionRadius;
    public bool playerInShootingRadius;

    [Header("Gangster Shooting var")]
    public float giveDamageOf = 1f;
    public float shootingRange = 100f;
    public GameObject shootingRaycastArea;
    public float timebtnShoot = 1f;
    bool previouslyShoot;
    public Player player;
    public ParticleSystem goreEffect;


    private void Start() {
        playerBody = GameObject.Find("Player");
        currentMovingSpeed = movingSpeed;
        presentHealth = characterHealth;
        player = GameObject.FindObjectOfType<Player>();

    }

    private void Update() {
        playerInVisionRadius = Physics.CheckSphere(transform.position, visionRadius, layerMask);
        playerInShootingRadius = Physics.CheckSphere(transform.position, shootingRadius, layerMask);

        if(!playerInVisionRadius && !playerInShootingRadius) {
            Walk();
        }
        if(playerInVisionRadius && !playerInShootingRadius) {
            ChasePlayer();
        }
        if(playerInVisionRadius && playerInShootingRadius) {
            ShootPlayer();
        }
    }

    public void Walk() {
         if(transform.position != destination) {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= stopSpeed) {
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
                animator.SetBool("Walk", true);
                animator.SetBool("Shoot", false);
                animator.SetBool("Run", false);
            }
            else {
                destinationReached = true;
            }
        }
    }

    public void LocateDestination(Vector3 destination) {
        this.destination = destination;
        destinationReached = false;
    }

    public void ChasePlayer() {
        animator.SetBool("Walk", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Run", true);
        transform.position += transform.forward * currentMovingSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);
        currentMovingSpeed = runningSpeed;
    } 

    public void ShootPlayer() {
        animator.SetBool("Walk", false);
        animator.SetBool("Shoot", true);
        animator.SetBool("Run", false);
        currentMovingSpeed = 0f;
        transform.LookAt(playerBody.transform);
        if(!previouslyShoot) {
            RaycastHit hit; 
            if(Physics.Raycast(shootingRaycastArea.transform.position, shootingRaycastArea.transform.forward, out hit, shootingRange)) {
                PlayerScript playerBody = hit.transform.GetComponent<PlayerScript>();
                if(playerBody != null) {
                    playerBody.playerHitDamage(giveDamageOf);
                    Instantiate(goreEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timebtnShoot);
        }   
    }  

    private void ActiveShooting() {
        previouslyShoot = false;
    }

    public void characterHitDamage(float takeDamage) {
        presentHealth -= takeDamage;

        if(presentHealth <= 0f) {
            animator.SetBool("Die", true);
            characterDie();
        }
    }

    public void characterDie() {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        currentMovingSpeed = 0f;
        shootingRange = 0f;
        Object.Destroy(gameObject, 4.0f);
        player.playerMoney += 200;
    }
}
