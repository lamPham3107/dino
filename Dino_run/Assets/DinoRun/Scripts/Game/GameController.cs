using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }



    public Text distanceText;
    private float distance;
    public float distanceIncreaseRate = 5f; // diem tang moi giay
    private float distanceTimer = 0f;

    public Image img_pause;
    public bool isPause = true;
    private bool isPopupActive = false;



    public GameObject pn_EndGame;
    public Text txt_distance_endgame;
    public Text txt_highest;
    private bool isEndGame = false;
    private void Start()
    {
        Pause(); 
    }

    private void Update()
    {
        if(isPause && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isPopupActive && !isEndGame)
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
    public void Pause()
    {
        Time.timeScale = 0f; 
        isPause = true;
        Debug.Log("Game Paused");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
        isPopupActive = false;
        img_pause.gameObject.SetActive(false);
        Debug.Log("Game Resumed");
    }
    public void Restart()
    {

        Time.timeScale = 1f;
        distance = 0f;
        isPopupActive = false;
        img_pause.gameObject.SetActive(false);
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
    public void PauseGame()
    {
        Pause();
        img_pause.gameObject.SetActive(true);
        isPopupActive = true;

    }
    public void EndGame()
    {
        StartCoroutine(WaitAndEndGame());
    }

    private IEnumerator WaitAndEndGame()
    {
        DinoController.animator.SetTrigger("die");
        yield return new WaitForSeconds(1f); 

        Pause();
        SaveHighestScore();
        isEndGame = true;
        txt_distance_endgame.text = distance.ToString("0") + "m";
        txt_highest.text = PlayerPrefs.GetFloat("HighestScore", 0f).ToString("0") + "m";
        pn_EndGame.SetActive(true);
    }
    public void SaveHighestScore()
    {
        float currentScore = GetScore();
        float highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
        if (currentScore > highestScore)
        {
            PlayerPrefs.SetFloat("HighestScore", currentScore);
            PlayerPrefs.Save();
        }
    }
}
