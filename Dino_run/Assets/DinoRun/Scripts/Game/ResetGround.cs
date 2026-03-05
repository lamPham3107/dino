using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGround : MonoBehaviour
{
    private Vector3 spawnPos;
    public List<GameObject> groundPrefabs;
    public List<float> groundWidths;
    private float holeWidth = 5f;
    private float Ground_width;


    private Transform groundStart;
    private void Start()
    {
        Ground_width = groundWidths[0];
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.transform.CompareTag("Endground"))
        {
            Transform groundParent = collision.transform.parent;
            Destroy(groundParent.gameObject);
        }
        if(collision != null && collision.transform.CompareTag("Startground"))
        {
            Transform groundParent = collision.transform.parent;
            groundStart = groundParent;

            int maxGround = unlockGround();
            int randomIndex = Random.Range(0, maxGround);

            float new_width = groundWidths[randomIndex];
            float pos_X = groundParent.position.x + holeWidth + Ground_width;

            spawnPos = new Vector3(pos_X, groundParent.position.y, 0f);
            changeWidth(new_width);
            SpawnGround(randomIndex);
        }
        if(collision != null && collision.transform.CompareTag("Bug"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnGround(int id)
    {
        GameObject randomGround = groundPrefabs[id];
        GameObject newGround = Instantiate(randomGround, spawnPos, Quaternion.identity);
        newGround.transform.parent = GameObject.Find("GroundList").transform;  // Gán làm con

    }
    private void changeWidth(float width)
    {
        Ground_width = width;

    }

    private int unlockGround()
    {

        if (LandMove.speed > 11f)
        {
            return groundPrefabs.Count;
        }
        else if (LandMove.speed > 10f && LandMove.speed <= 11f)
        {
            return 6;
        }
        else
        {
            return 3;
        };


    }


}
