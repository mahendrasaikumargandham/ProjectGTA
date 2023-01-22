using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject[] AiPrefab;
    public int AiToSpawn;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        int count = 0;
        while(count < AiToSpawn) {
            int randomIndex = Random.Range(0, AiPrefab.Length);

            GameObject obj = Instantiate(AiPrefab[randomIndex]);

            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WayPointNavigator>().currentWayPoint = child.GetComponent<WayPoint>();

            obj.transform.position = child.position;
            yield return new WaitForSeconds(1f);
            count++;
        }
    }
}
