using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{

    public string sortingLayerName = "Default"; // The name of the sorting layer to set
    public int sortingOrder = 0; // The sorting order within the layer

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = sortingLayerName;
        meshRenderer.sortingOrder = sortingOrder;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
