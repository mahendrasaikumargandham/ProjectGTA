using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [Header("Object Health")]
    public float objectHealth = 120f;

    public void ObjectHitDamage(float amount) {
        objectHealth -= amount;

        if(objectHealth <= 0f) {
            Die();
        }
    } 

    void Die() {
        Destroy(gameObject);
    }
}
