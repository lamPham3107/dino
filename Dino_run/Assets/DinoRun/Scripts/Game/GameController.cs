using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
    private bool isPause = true;

    public Text distanceText;
    private float distance;
    public float distanceIncreaseRate = 5f; // doem tang moi giay
    private float distanceTimer = 0f;


    private void Start()
    {
        Pause(); 
    }

    private void Update()
    {
        if(isPause && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            Resume();
 
        }
        if (!isPause)
        {
            // tang diem 5 lan moi giay
            distanceTimer += Time.deltaTime;
            if (distanceTimer >= 1f / distanceIncreaseRate)
            {
                changeDistance();
                distanceTimer = 0f;
            }
        }
    }
    private void Pause()
    {
        Time.timeScale = 0f; 
        isPause = true;
        Debug.Log("Game Paused");
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
        Debug.Log("Game Resumed");
    }
    private void Restart()
    {
        Time.timeScale = 1f;
        distance = 0f;
        SceneManager.LoadScene("Game");
        Debug.Log("Game Restarted");
    }
    private void changeDistance()
    {
        distance++;
        distanceText.text = distance.ToString("0") + " m";
    }
    public static float GetScore()
    {
        return instance.distance;
    }
}
