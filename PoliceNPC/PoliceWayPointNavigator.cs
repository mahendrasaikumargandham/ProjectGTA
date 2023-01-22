using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceWayPointNavigator : MonoBehaviour
{
    [Header("NPC Character")]
    public PoliceOfficer character;
    public WayPoint currentWayPoint;
    public int direction;


    private void Awake() {
        character = GetComponent<PoliceOfficer>();
    }

    private void Start() {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        character.LocateDestination(currentWayPoint.GetPosition());
    }

    private void Update() {
        if(character.destinationReached) {
            bool shouldBranch = false;

            if(currentWayPoint.branches != null && currentWayPoint.branches.Count > 0) {
                shouldBranch = Random.Range(0f, 1f) <= currentWayPoint.branchRatio ? true : false;
            }
            else {
                if(shouldBranch) {
                    currentWayPoint = currentWayPoint.branches[Random.Range(0, currentWayPoint.branches.Count - 1)];
                }
                if(direction == 0) {
                    if(currentWayPoint.nextWayPoint != null) {
                        currentWayPoint = currentWayPoint.nextWayPoint;
                    }
                    else {
                        currentWayPoint = currentWayPoint.previousWayPoint;
                        direction = 1;
                    }
                }
                else if(direction == 1) {
                    if(currentWayPoint.previousWayPoint != null) {
                        currentWayPoint = currentWayPoint.previousWayPoint;
                    }
                    else {
                        currentWayPoint = currentWayPoint.nextWayPoint;
                        direction = 0;
                    }
                }
            }
            character.LocateDestination(currentWayPoint.GetPosition());
        }
    }
}
