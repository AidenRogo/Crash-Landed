using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool isPowered = false; // Flag to check if the generator is powered
    public Elevator Elevator; // Reference to the Elevator component

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


void OnTriggerEnter2D(Collider2D other) //Ensure that the collision is 2D!!!
    {
        if (other.CompareTag("Fuse")) 
        {
            Debug.Log("Fuse has Collided with Generator");
           
            isPowered = true; // Toggle the isPowered flag
            Elevator.GeneratorPowered(); // Call the GeneratorPowered method in the Elevator script

        }else{
           isPowered = false;
        }
    }

}
