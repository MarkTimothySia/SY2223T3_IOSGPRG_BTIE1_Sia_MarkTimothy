using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform SpawnerPos;

    // Since no max here

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTick());
    }


    IEnumerator SpawnTick()
    {
        yield return new WaitForSeconds(spawnTimer); // wait first then start again

        Instantiate(EnemyPrefab, SpawnerPos);

        StartCoroutine(SpawnTick());
    }
}
