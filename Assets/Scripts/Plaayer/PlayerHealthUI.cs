using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("UI References")]
    // Reference to the Slider UI element that displays the player's health.
    public Slider healthSlider;

    [Header("Player Reference")]
    // Reference to the player's script (ensure the Player object has this script attached).
    public Player player;

    void Start()
    {
        // When the UI initializes, set the slider's max value to the player's starting health.
        if (player != null && healthSlider != null)
        {
            healthSlider.maxValue = player.Lives;
            healthSlider.value = player.Lives;
        }
    }

    void Update()
    {
        // Continuously update the slider's value to match the player's current health.
        if (player != null && healthSlider != null)
        {
            healthSlider.value = player.Lives;
        }
    }

    void LateUpdate()
    {
        // Force the UI element to remain with no rotation in world space.
        if (healthSlider != null)
        {
            healthSlider.transform.rotation = Quaternion.identity;
        }
    }






}