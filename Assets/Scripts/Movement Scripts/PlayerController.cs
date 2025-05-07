using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    //PlayerController
    public Input playerControls;
    public Animator CharacterAnimator;

    //Movement
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 moveDirection = Vector2.zero;
    public InputAction move;
    private bool isPushing;

    //Wrench
    public GameObject wrenchHitBox;
    public GameObject wrenchHighBox;
    private InputAction fire;
    public bool isSwinging;

    //Annoyed of wrench making off button
    public bool wrenchOn = true;

    //Cutscene
    //public bool wantCutscene;



    //Start, Awake, OnEnable, and OnDisable 
    //functions that are called on the first frame;
    void Start()
    {
        isSwinging = false;
        isPushing = false;
        wrenchHitBox.SetActive(false);
        wrenchHighBox.SetActive(true);
        CharacterAnimator.SetBool("FaceFront", true);
        /*if (wantCutscene)
        {
            startCutscene();
        }*/

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
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(0, .4f, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 0;
            wrenchHighBox.transform.position = rb.transform.position + new Vector3(0, .4f, 0);
            wrenchHighBox.transform.eulerAngles = Vector3.forward * 0;
        }
        if (moveDirection.x == 1)
        {
        
            CharacterAnimator.SetBool("FaceLeft", false);
            CharacterAnimator.SetBool("FaceRight", true);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", false);
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(.4f, 0, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * -90;
            wrenchHighBox.transform.position = rb.transform.position + new Vector3(.4f, 0, 0);
            wrenchHighBox.transform.eulerAngles = Vector3.forward * -90;

        }
        if (moveDirection.y < -.7)
        {
    
            CharacterAnimator.SetBool("FaceLeft", false);
            CharacterAnimator.SetBool("FaceRight", false);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", true);
            wrenchHitBox.transform.position = rb.transform.position + new Vector3(0, -.4f, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 180; 
            wrenchHighBox.transform.position = rb.transform.position + new Vector3(0, -.4f, 0);
            wrenchHighBox.transform.eulerAngles = Vector3.forward * 180;


        }
        if (moveDirection.x == -1)
        {

            CharacterAnimator.SetBool("FaceLeft", true);
            CharacterAnimator.SetBool("FaceRight", false);
            CharacterAnimator.SetBool("FaceBack", false);
            CharacterAnimator.SetBool("FaceFront", false);

            wrenchHitBox.transform.position = rb.transform.position + new Vector3(-.4f, 0, 0);
            wrenchHitBox.transform.eulerAngles = Vector3.forward * 90;
            wrenchHighBox.transform.position = rb.transform.position + new Vector3(-.4f, 0, 0);
            wrenchHighBox.transform.eulerAngles = Vector3.forward * 90;


        }
        
    }

    //Left click calls this function
    private void Fire(InputAction.CallbackContext context)
    {
        if (!isSwinging && wrenchOn)
        {
            Debug.Log("Swung Wrench");
            StartCoroutine(Swing());
        }
    }

    //Activates and Deativates the wrench hitbox
    //Movement is disables when called
    IEnumerator Swing()
    {
        isSwinging = true;
        move.Disable();

        CharacterAnimator.SetBool("isSwinging", true);
        yield return new WaitForSeconds(0.4f);
        wrenchHitBox.SetActive(true);
        yield return new WaitForSeconds(0.333f);
        isSwinging = false;
        wrenchHitBox.SetActive(false);
        CharacterAnimator.SetBool("isSwinging", false);
        move.Enable();

    }



    void OnCollisionEnter2D(Collision2D other) // Ensure that the collision is 2D
    {
        if ((other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Fuse")))
        {
            Debug.Log("Is Pushing");

            isPushing = true;
            CharacterAnimator.SetBool("isPushing", isPushing);
            
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Fuse")))
        {
            CharacterAnimator.SetFloat("ObjSpeed", other.rigidbody.velocity.magnitude);
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {

        if ((other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Fuse")))
        {
            Debug.Log("Not Pushing");

            isPushing = false;
            CharacterAnimator.SetBool("isPushing", isPushing);
        }
    }

    
}
