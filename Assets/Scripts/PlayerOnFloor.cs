using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnFloor : MonoBehaviour
{
    private int onFloor = 0;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor++;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            onFloor--;
        }
        if (onFloor < 1)
        {
            Player.transform.position = new Vector3(-7.8f, 13.85f, 0);

        }
    }
}
