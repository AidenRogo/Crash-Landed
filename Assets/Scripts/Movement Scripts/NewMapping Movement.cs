using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMappingMovement : MonoBehaviour
{
    //Movement
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;
    private InputAction move;



    //Sprites
    [SerializeField] Sprite[] playerSprites;
    [SerializeField] Sprite newSprite;

    //Wrench
    private bool isSwinging;
    public GameObject wrenchHitBox;
    public GameObject visualHitBox;
    public Input playerControls;
    private InputAction fire;

    void Start()
    {
        isSwinging = false;
    }

    private void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
        playerControls = new Input();

    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();


        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

    }
    public void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

    }

    private void OnMove(InputValue inputValue)
    {

        moveDirection = inputValue.Get<Vector2>();
        Debug.Log(moveDirection);
        if (inputValue.Get<Vector2>().y >.7)
        {
            newSprite = playerSprites[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        if (inputValue.Get<Vector2>().x == 1)
        {
            newSprite = playerSprites[3];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        if (inputValue.Get<Vector2>().y <-.7)
        {
            newSprite = playerSprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        if (inputValue.Get<Vector2>().x == -1)
        {
            newSprite = playerSprites[2];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }


    private void Fire(InputAction.CallbackContext context)
    {

        if (!isSwinging)
        {
            Debug.Log("Swung Wrench");
            StartCoroutine(Swing());

        }
    }

    IEnumerator Swing()
    {
        if (newSprite == playerSprites[0])
        {
       
            isSwinging = true;
            wrenchHitBox.transform.Translate(0, 1, 0);
            visualHitBox.transform.Translate(0, 1, 0);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(true);
            visualHitBox.SetActive(true);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(false);
            visualHitBox.SetActive(false);
            wrenchHitBox.transform.Translate(0, -1, 0);
            visualHitBox.transform.Translate(0, -1, 0);
            isSwinging = false;
            
        }
        if (newSprite == playerSprites[3])
        {

            isSwinging = true;
            wrenchHitBox.transform.Translate(1, 0, 0);
            visualHitBox.transform.Translate(1, 0, 0);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(true);
            visualHitBox.SetActive(true);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(false);
            visualHitBox.SetActive(false);
            wrenchHitBox.transform.Translate(-1, 0, 0);
            visualHitBox.transform.Translate(-1, 0, 0);
            isSwinging = false;
         
        }
        if (newSprite == playerSprites[1])
        {
            isSwinging = true;
            wrenchHitBox.transform.Translate(0, -1, 0);
            visualHitBox.transform.Translate(0, -1, 0);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(true);
            visualHitBox.SetActive(true);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(false);
            visualHitBox.SetActive(false);
            wrenchHitBox.transform.Translate(0, 1, 0);
            visualHitBox.transform.Translate(0, 1, 0);
            isSwinging = false;
            
        }
        if (newSprite == playerSprites[2])
        {
            
            isSwinging = true;
            wrenchHitBox.transform.Translate(-1, 0, 0);
            visualHitBox.transform.Translate(-1, 0, 0);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(true);
            visualHitBox.SetActive(true);
            yield return new WaitForSeconds(.5f);
            wrenchHitBox.SetActive(false);
            visualHitBox.SetActive(false);
            wrenchHitBox.transform.Translate(1, 0, 0);
            visualHitBox.transform.Translate(1, 0, 0);
            isSwinging = false;
            
        }


    }

}
   


