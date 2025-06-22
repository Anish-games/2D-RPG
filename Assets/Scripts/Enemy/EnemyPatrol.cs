using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float speed = 2f;
    public Transform edgeDetection;
    public float groundCheckDistance = 1f;

    private bool movingRight = true;
    // Flag to disable movement when in attack mode.
    public bool isAttackMode = false;

    // Reference to the player.
    public Player player;

    [Header("Attack Settings")]
    public float attackRate = 1f; // Time (in seconds) between attacks
    // Reference to the Animator to control the attack animation.
    public Animator animator;

    // Reference to the ongoing attack coroutine.
    private Coroutine attackCoroutine;

    void Update()
    {
        // Skip patrol movement if attack mode is engaged.
        if (isAttackMode)
            return;

        Patrol();
    }

    void Patrol()
    {
        float moveDirection = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(edgeDetection.position, Vector2.down, groundCheckDistance);
        if (groundInfo.collider == null || !groundInfo.collider.CompareTag("Ground"))
        {
            Flip();
        }
    }


    public void Flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Represents an attack action (for example, a sword swing).
    public void AttackPlayer()
    {
        Debug.Log("Enemy attacks the player!");

        // Use the trigger instead of a boolean.
        if (animator != null)
        {
            animator.SetTrigger("attack");
        }
        if (player != null)
        {
            // DamagePlayer() should handle the damage logic.
            player.DamagePlayer();
        }
    }

    // Call to begin attack mode.
    public void EnterAttackMode()
    {
        if (!isAttackMode)
        {
            isAttackMode = true;
            // Start calling AttackPlayer repeatedly.
            attackCoroutine = StartCoroutine(ContinuousAttack());
        }
    }

    // Call to stop attack mode.
    public void ExitAttackMode()
    {
        isAttackMode = false;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    // Coroutine to attack continuously while in attack mode.
    private IEnumerator ContinuousAttack()
    {
        while (isAttackMode)
        {
            AttackPlayer(); // Damage the player and play attack animation.
            yield return new WaitForSeconds(attackRate);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (edgeDetection != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(edgeDetection.position, edgeDetection.position + Vector3.down * groundCheckDistance);
        }
    }
}