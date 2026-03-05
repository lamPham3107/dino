using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBug : MonoBehaviour
{
    public List<GameObject> bugPrefabs;
    public GameObject spamwnPos;

    private float spawnTime = 5f;
    private float timer = 0f;
    private bool canSpawn = false;
    private void Start()
    {
        timer = spawnTime;
    }
    private void Update()
    {

        if (!canSpawn && GameController.GetDistance() > 20)
        {
            canSpawn = true;
        }

        if (canSpawn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                //int ramdomSpawnQuantity = Random.Range(1, 3);
                int ramdomSpawnQuantity = 1;
                while (ramdomSpawnQuantity > 0)
                {
                    ramdomSpawnQuantity--;
                    Spawn();
                }
                timer = spawnTime;
            }
        }
    }

    private void Spawn()
    {
        int ramdomIndex = Random.Range(0, bugPrefabs.Count);
        float randomYOffset = Random.Range(-2f, 0f);
        float ramdomXOffset = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(spamwnPos.transform.position.x + ramdomXOffset, spamwnPos.transform.position.y + randomYOffset, spamwnPos.transform.position.z);
        GameObject bug = Instantiate(bugPrefabs[ramdomIndex], spawnPosition, Quaternion.identity);
    }
}
