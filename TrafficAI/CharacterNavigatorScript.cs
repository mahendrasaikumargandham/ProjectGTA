using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigatorScript : MonoBehaviour
{
    [Header("Character info")]
    public float movingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;
    private float characterHealth = 200f;
    public float presentHealth;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;
    public Animator animator;
    public Player player;

    private void Update() {
        Walk();
        player = GameObject.FindObjectOfType<Player>();
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

    public void characterHitDamage(float takeDamage) {
        presentHealth -= takeDamage;

        if(presentHealth <= 0f) {
            animator.SetBool("Die", true);
            characterDie();
        }
    }

    public void characterDie() {
        movingSpeed = 0f;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        player.currentKills += 1;
        player.playerMoney += 100;
        Object.Destroy(gameObject, 4.0f);
    }
}
