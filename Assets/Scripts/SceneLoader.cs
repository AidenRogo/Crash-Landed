using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    public Animator Transition;
    public float transitionTime = 1f;

    //Loads the next scene by index
    //The index is found int the build settings
    public void LoadSceneByIndex(int SceneIndex)
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + SceneIndex));
    }

    // public void RestartLevel(InputAction.CallbackContext context)
    // {   
              

    //     if (context.performed)
    //     {
    //         Debug.Log("Level Restarted");
    //         StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
     
    //     }
       

      
    // }



    // IEnumerator LoadLevel(int levelIndex){
    //     //play the transition animation
    //     Transition.SetTrigger("Start");
    //     //wait for the animation to finish
    //     yield return new WaitForSeconds(transitionTime);
    //     //load the scene
    //     SceneManager.LoadScene(levelIndex);


    // }

    IEnumerator LoadLevel(int levelIndex)
{
    // Play the transition animation
    Transition.SetTrigger("Start");

    // Wait for the animation to finish
    yield return new WaitForSeconds(transitionTime);

    // Reset the trigger to allow future transitions
    Transition.ResetTrigger("Start");

    // Load the scene
    SceneManager.LoadScene(levelIndex);
}









    //should hopefully quit the appication
    //wont know until we have a build
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}