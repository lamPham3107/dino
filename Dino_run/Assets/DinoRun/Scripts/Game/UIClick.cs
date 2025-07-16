using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClick : MonoBehaviour
{
    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
