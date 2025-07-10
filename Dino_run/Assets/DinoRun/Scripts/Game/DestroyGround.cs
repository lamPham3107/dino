using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    private Vector3 spawnPos;
    public List<GameObject> groundPrefabs;
    public List<float> groundWidths;
    private float holeWidth = 4f;
    private float Ground_1_width;
    private float Ground_2_width;

    private void Start()
    {
        Ground_1_width = groundWidths[0];
        Ground_2_width = groundWidths[1];


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
            Debug.Log("Ground Parent Position: " + groundParent.position);

            int randomIndex = Random.Range(0, groundPrefabs.Count);
            float new_width = groundWidths[randomIndex];

            float pos_X = groundParent.position.x + 2*holeWidth + Ground_1_width/2f + Ground_2_width + new_width/2f;
            spawnPos = new Vector3(pos_X, groundParent.position.y, 0f);
            changeWidth(new_width);

            SpawnGround(randomIndex);

        }
    }

    private void SpawnGround(int id)
    {
        GameObject randomGround = groundPrefabs[id];


        GameObject newGround = Instantiate(randomGround, spawnPos, Quaternion.identity);
        newGround.transform.parent = GameObject.Find("Ground").transform;  // Gán làm con

    }
    private void changeWidth(float width)
    {
        Ground_1_width = Ground_2_width;
        Ground_2_width = width;
    }
}
