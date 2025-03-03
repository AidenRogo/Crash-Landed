using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject paths;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        paths.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        paths.SetActive(true);
    }
}
