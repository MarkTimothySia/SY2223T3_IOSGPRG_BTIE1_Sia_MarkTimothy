using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject PowerUpPrefab;
    [SerializeField] GameObject Player;
    [SerializeField] Transform SpawnerPos;
    [SerializeField] Swipe SwipeManager;
    [SerializeField] TextMeshProUGUI EnemySpeedText;


    private float SpeedMulti = 1.0f;
    private float Multiplier = 0.5f;

    private int CurrentTotalEnemies;

    void Start()
    {
        StartCoroutine(C_SpawnTick());

        EnemyPrefab.GetComponent<EnemyScript>().SetSwipeManager(SwipeManager);
        EnemyPrefab.GetComponent<EnemyScript>().SetPlayer(Player);
    }

    private void LateUpdate()
    {
        EnemySpeedText.text = "Enemy Speed: " + SpeedMulti.ToString();
    }

    public void AddSpeed()
    {
        Multiplier +=  0.5f;
    }


    IEnumerator C_SpawnTick()
    {
        int ToSpawn = Random.Range(0,1);


        // wait first then start again
        yield return new WaitForSeconds(spawnTimer);

        if (ToSpawn == 0)
        {
            Instantiate(EnemyPrefab, SpawnerPos);

            CurrentTotalEnemies++;

            if (CurrentTotalEnemies < 5)
            {
                StartCoroutine(C_SpawnTick());
            }
        }
        else if (ToSpawn == 1)
        {
            Instantiate(PowerUpPrefab, SpawnerPos);
        }

         // Not sure if this works
         yield return new WaitForSeconds(spawnTimer);
         StartCoroutine(C_SpawnTick());
    }

    IEnumerator C_SpeedMultiTick()
    {
        yield return new WaitForSeconds(1);
        SpeedMulti = SpeedMulti + Multiplier;

        // Hope this works increase speed
        EnemyPrefab.GetComponent<EnemyScript>().SetSpeedMultiplier(SpeedMulti);
    }

}
