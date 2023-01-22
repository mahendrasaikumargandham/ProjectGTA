using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWayPointNavigator : MonoBehaviour
{
    [Header("Car AI")]
    public CarNavigatorScript car;
    public WayPoint currentWayPoint;

    private void Awake() {
        car = GetComponent<CarNavigatorScript>();
    }

    private void Start() {
        car.LocateDestination(currentWayPoint.GetPosition());
    }
    private void Update() {
        if(car.destinationReached) {
            currentWayPoint = currentWayPoint.nextWayPoint;
            car.LocateDestination(currentWayPoint.GetPosition());
        }
    }
}
