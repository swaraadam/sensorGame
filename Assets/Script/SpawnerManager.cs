using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    public List<GameObject> spawner = new List<GameObject>();
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawnObject(3));
	}
	
    IEnumerator spawnObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        int chooseSpawner = Random.Range(0, spawner.Count);
        Instantiate(enemy, spawner[chooseSpawner].transform.position, Quaternion.identity);
        StartCoroutine(spawnObject(3));
    }
}
