using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [Header("UI References")]
    // Reference to the Slider UI element that displays the enemy's health.
    public Slider healthSlider;

    [Header("Enemy Reference")]
    // Reference to the enemy's health script.
    public DestroyableObj enemy;

    private float maxHealth;

    void Start()
    {
        if (enemy != null && healthSlider != null)
        {
            // Save the initial enemy health as the maximum health.
            maxHealth = enemy.enemyHealth;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = enemy.enemyHealth;
        }
    }

    void Update()
    {
        if (enemy != null && healthSlider != null)
        {
            // Update the slider to represent the current enemy health.
            healthSlider.value = enemy.enemyHealth;
        }
    }

    void LateUpdate()
    {
        if (healthSlider != null)
        {
            // Force the health slider to remain upright irrespective of the enemy's rotation.
            healthSlider.transform.rotation = Quaternion.identity;
        }
    }
}