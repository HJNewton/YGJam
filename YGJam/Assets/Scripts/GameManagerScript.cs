using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuCam;
    public GameObject player;

    private void Start()
    {
        player.SetActive(false);
    }

    public void BeginGame()
    {
        menu.SetActive(false);
        menuCam.SetActive(false);
        player.SetActive(true);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
