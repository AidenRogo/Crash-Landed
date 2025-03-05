using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    //Loads the next scene by index
    //The index is found int the build settings
    public void LoadSceneByIndex(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    //should hopefully quit the appication
    //wont know until we have a build
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}