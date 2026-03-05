using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public GameObject smokePrefab; // gán trong Inspector
    public GameObject smoke;
    private bool isEating = false;
    public static int BugCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Bug") && !isEating)
        {
            StartCoroutine(WaitEat(collision.gameObject));
        }
    }

    private IEnumerator WaitEat(GameObject bug)
    {
        Debug.Log("Eating bug...");
        isEating = true;
        Collider2D bugCollider = bug.GetComponent<Collider2D>();
        if (bugCollider != null) bugCollider.enabled = false;
        DinoController.animator.SetBool("eat", true);
        if (smokePrefab != null)
        {
            Vector3 smokePos = new Vector3(bug.transform.position.x - 3f, bug.transform.position.y, 0f);
            smoke = Instantiate(smokePrefab, smokePos, Quaternion.identity);
        }

        yield return new WaitForSeconds(0.1f);
        Destroy(bug);
        DinoController.animator.SetBool("eat", false);
        isEating = false;
        Destroy(smoke);
        BugCount++;

    }
}
