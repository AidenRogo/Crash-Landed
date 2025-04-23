using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLogo : MonoBehaviour
{
    public Transform LogoSprite; // Reference to the logo sprite
    public float amplitude = 50f; // Amplitude of the bobbing motion (how far it moves up and down)
    public float frequency = 1f; // Frequency of the bobbing motion (how fast it moves up and down)

    private Vector3 originalPosition; // Original position of the logo sprite

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = LogoSprite.position; // Store the original position of the sprite
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position using a sine wave
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        LogoSprite.position = originalPosition + new Vector3(0, yOffset, 0);
    }
}
