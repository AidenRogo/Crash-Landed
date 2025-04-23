using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool isPowered = false; // Flag to check if the generator is powered
    public EndElevator elevator; // Reference to the Elevator component
    private Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    // Update is called once per frame
    void Update() //Nothing in here right now
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) // Ensure that the collision is 2D
    {
        if (other.CompareTag("Fuse")) // Check if the collided GameObject has the "Fuse" tag
        {
            Debug.Log("Fuse has Collided with Generator");
           
            isPowered = true; // Toggle the isPowered flag
            elevator.GeneratorPowered(); // Call the GeneratorPowered method in the Elevator script

            animator.SetTrigger("PowerOn"); // Trigger the "PowerOn" animation
            Destroy(other.gameObject); // Destroy the fuse GameObject
        }
    }
}
