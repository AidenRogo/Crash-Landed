using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CheckWrenchActivatesSwitchActivatesDoor : InputTestFixture
{
    Keyboard keyboard;
    Mouse mouse;

    GameObject Door;
    GameObject Switch;

    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene("scenes/TEST Scenes/TEST 1");
        // Need to call parent's setup method
        
        // create the fake input devices
        keyboard = InputSystem.AddDevice<Keyboard>("keyboard");
        mouse = InputSystem.AddDevice<Mouse>("mouse");
        // click into the game to give it control (may not need this)
        //Press(mouse.leftButton);
        //Release(mouse.leftButton);
    }

    

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CheckWrenchActivatesSwitchActivatesDoorWithEnumeratorPasses()
    {
        Door = GameObject.FindGameObjectWithTag("Door");
        Switch = GameObject.FindGameObjectWithTag("Switch");
        
        LockedDoor DoorScript = Door.GetComponent<LockedDoor>();
        yield return new WaitForSeconds(2.1f);

        Press(keyboard.wKey);
        yield return new WaitForSeconds(0.01f);
        Release(keyboard.wKey);
        yield return new WaitForSeconds(0.01f);

        Press(mouse.leftButton);
        yield return new WaitForSeconds(0.01f);
        Release(mouse.leftButton);
        yield return new WaitForSeconds(3f);

        Assert.That(DoorScript.isOpen, Is.True);

        yield return null;
    }
    [TearDown]
    public override void TearDown()
    {
        var playerInputs = GameObject.FindObjectsOfType<PlayerInput>();
        foreach (var playerInput in playerInputs)
        {
            Object.DestroyImmediate(playerInput.gameObject);
        }
        base.TearDown();
    }
}
