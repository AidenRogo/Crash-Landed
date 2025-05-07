using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CheckCheckPoint: InputTestFixture
{
    Keyboard keyboard;
    Mouse mouse;

    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene("scenes/TEST Scenes/TEST 2");
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
    public IEnumerator CheckCheckPointWithEnumeratorPasses()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject CheckPoint = GameObject.FindGameObjectWithTag("SpawnPointSet");
        Vector2 firstPosition = Player.transform.position;
        Vector2 checkPointPosition = CheckPoint.transform.position;
        Debug.Log(checkPointPosition);
        yield return new WaitForSeconds(2.1f);

        Press(keyboard.wKey);

        yield return new WaitForSeconds(1f);

        Release(keyboard.wKey);

        yield return new WaitForSeconds(1f);

        Assert.That(Player.transform.position.x, Is.EqualTo(firstPosition.x).Within(.001));
        Assert.That(Player.transform.position.y, Is.EqualTo(firstPosition.y).Within(.001));

        Press(keyboard.aKey);

        yield return new WaitForSeconds(2.5f);
        Release(keyboard.aKey);
        yield return null;
        Press(keyboard.wKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.wKey);

        yield return new WaitForSeconds(2f);

        Debug.Log(Player.transform.position);

        Assert.That(Player.transform.position.x, Is.EqualTo(checkPointPosition.x).Within(.001));
        Assert.That(Player.transform.position.y, Is.EqualTo(checkPointPosition.y).Within(.75));

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
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
