using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform edgeDetection;
    public float groundCheckDistance = 1f;

    private bool movingRight = true;

    void Update()
    {
       
        float moveDirection = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);

        
        RaycastHit2D groundInfo = Physics2D.Raycast(edgeDetection.position, Vector2.down, groundCheckDistance);

        // If there's no ground, flip direction
        if (groundInfo.collider == null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
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