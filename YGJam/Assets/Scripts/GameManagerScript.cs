using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
