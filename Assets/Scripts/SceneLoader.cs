using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Aiden Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}