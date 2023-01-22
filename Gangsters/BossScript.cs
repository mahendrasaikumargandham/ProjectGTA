using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    float bossHealth = 120f;
    public Animator animator;
    public Player player;
    public Missions missions;

    private void Update() {
        if(bossHealth < 120f) {
            animator.SetBool("Shooting", true);
        }
        if(bossHealth <= 0f) {

            if(missions.Mission1 == true && missions.Mission2 == true && missions.Mission3 == true) {
                missions.Mission4 = true;
                player.playerMoney += 1000;
            }
            Object.Destroy(gameObject, 4.0f);
            animator.SetBool("Shooting", false);
            animator.SetBool("Died", true);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    } 

    public void characterHitDamage(float takeDamage) {
        bossHealth -= takeDamage;
    }
}
