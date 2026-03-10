using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGround : MonoBehaviour
{
    private Vector3 spawnPos;
    public List<GameObject> groundPrefabs;
    public List<float> groundWidths;
    private float holeWidth = 5.5f;
    private float Ground_width;
    private Transform groundListParent;

    private Transform groundStart;
    private void Start()
    {
        Ground_width = groundWidths[0];
        groundListParent = GameObject.Find("GroundList").transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameController.instance.isEndGame) return;

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
        if (GameController.instance.isEndGame) return;

        GameObject randomGround = groundPrefabs[id];
        GameObject newGround = Instantiate(randomGround, spawnPos, Quaternion.identity);
        StartCoroutine(SetParentNextFrame(newGround));

    }

    private IEnumerator SetParentNextFrame(GameObject newGround)
    {
        yield return null; // Chờ 1 frame
        if (newGround != null && groundListParent != null)
        {
            newGround.transform.parent = groundListParent;
        }
    }
    private void changeWidth(float width)
    {
        Ground_width = width;

    }

    private int unlockGround()
    {
        //return groundPrefabs.Count;
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
