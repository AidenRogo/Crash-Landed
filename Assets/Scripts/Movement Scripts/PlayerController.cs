using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //PlayerController
    public Input playerControls;
    public Animator CharacterAnimator;

    //Movement
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private bool isPushing;

    //Wrench
    public GameObject wrenchHitBox;
    private InputAction fire;
    private bool isSwinging;




    //Start, Awake, OnEnable, and OnDisable 
    //functions that are called on the first frame;
    void Start()
    {
        isSwinging = false;
        isPushing = false;
        wrenchHitBox.SetActive(false);
        CharacterAnimator.SetBool("FaceFront", true);

    }
    private void Awake()
    {
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
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }



    // Update and FixedUpdate are called every frame;
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        CharacterAnimator.SetFloat("Speed",  moveDirection.magnitude);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        //Changes the sprite based on the direction the character is facing
        if (moveDirection.y > .7)
        {
            
            CharacterAnimator.SetBool("FaceLeft", false);
            CharacterAnimator.SetBool("FaceRight", false);
            CharacterAnimator.SetBool("FaceBack", true);
            CharacterAnimator.SetBool("FaceFront", false);
        }
        if (moveDirection.x == 1)
        {
        
            CharacterAnimator.SetBool("FaceLeft", false);
            CharacterAnimator.SetBool("FaceRight", true);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", false);

        }
        if (moveDirection.y < -.7)
        {
    
            CharacterAnimator.SetBool("FaceLeft", false);
            CharacterAnimator.SetBool("FaceRight", false);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", true);

        }
        if (moveDirection.x == -1)
        {

            CharacterAnimator.SetBool("FaceLeft", true);
            CharacterAnimator.SetBool("FaceRight", false);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", false);




        }
        
    }

    //Left click calls this function
    private void Fire(InputAction.CallbackContext context)
    {
        if (!isSwinging)
        {
            Debug.Log("Swung Wrench");
            StartCoroutine(Swing());
        }
    }

    //Activates and Deativates the wrench hitbox
    //Movement is disables when called
    IEnumerator Swing()
    {
        move.Disable();

        isSwinging = true;
        CharacterAnimator.SetBool("isSwinging", isSwinging);
        yield return new WaitForSeconds(0.5f);
        if (CharacterAnimator.GetBool("FaceFront"))
        {
            wrenchHitBox.transform.position = rb.transform.position +  new Vector3(0,-.4f,0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 180;
            wrenchHitBox.SetActive(true);

        }
        if (CharacterAnimator.GetBool("FaceBack"))
        {
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(0, .4f, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 0;

            wrenchHitBox.SetActive(true);
        }
        if (CharacterAnimator.GetBool("FaceLeft"))
        {
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(-.4f, 0, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 90;

            wrenchHitBox.SetActive(true);
        }
        if (CharacterAnimator.GetBool("FaceRight"))
        {
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(.4f, 0, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * -90;

            wrenchHitBox.SetActive(true);
        }


        yield return new WaitForSeconds(0.5f);
        isSwinging = false;
        CharacterAnimator.SetBool("isSwinging", isSwinging);
        wrenchHitBox.SetActive(false);
        move.Enable();

    }



    void OnCollisionEnter2D(Collision2D other) // Ensure that the collision is 2D
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Fuse"))
        {
            Debug.Log("Is Pushing");

            isPushing = true;
            CharacterAnimator.SetBool("isPushing", isPushing);
            
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Fuse"))
        {
            Debug.Log("Not Pushing");

            isPushing = false;
            CharacterAnimator.SetBool("isPushing", isPushing);
        }
    }
}
