using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] Sprite[] playerSprites;
    [SerializeField] Sprite newSprite;
    private Vector2 _movementInput;

    private void OnMove(InputValue inputValue)
    {
       // _movementInput = inputValue.Get<Vector2>();

        if (inputValue.Get<Vector2>().x == 1)
        {
            newSprite = playerSprites[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }



    }
}
