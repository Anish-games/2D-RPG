using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [Tooltip("Check this if this trigger represents the front of the enemy.")]
    public bool isFront = true;

    private EnemyPatrol enemy;

    void Start()
    {
        // Finds the enemy component in the parent.
        enemy = GetComponentInParent<EnemyPatrol>();
        if (enemy == null)
        {
            Debug.LogError("EnemyTrigger: Cannot find EnemyPatrol component on parent!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only respond when colliding with the player.
        if (collision.CompareTag("Player"))
        {
            enemy.EnterAttackMode();
            if (!isFront)
            {
                // For the back trigger, flip first before attacking.
                enemy.Flip();
            }
            enemy.AttackPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.ExitAttackMode();
        }
    }
}