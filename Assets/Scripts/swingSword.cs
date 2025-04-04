using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class swingSword : MonoBehaviour
{
    private bool isSwinging;
    public GameObject wrenchHitBox;
    public GameObject visualHitBox;
    public Input playerControls;

    private InputAction fire;

    private void Awake()
    {
        playerControls = new Input();
    }
        
    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        fire.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        isSwinging = false;
        wrenchHitBox.SetActive(false);
        visualHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        isSwinging = true;
        yield return new WaitForSeconds(.5f);
        wrenchHitBox.SetActive(true);
       // visualHitBox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        wrenchHitBox.SetActive(false);
      //  visualHitBox.SetActive(false);
        isSwinging=false;
    }
}
