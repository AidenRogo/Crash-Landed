using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteractable : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void unHighlight()
    {
        sprite.color = Color.white;

    }
    public void Highlight()
    {
        sprite.color = Color.yellow;

    }
}

