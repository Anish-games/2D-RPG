using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    private float moveInput;

    private Rigidbody2D rb;


    private bool isHeFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (rb != null)
        {

            moveInput = Input.GetAxis("Horizontal");

            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

            if (isHeFacingRight == false && moveInput > 0)
            {
                flip();
            }
            else if (isHeFacingRight == true && moveInput < 0)
            {
                flip();
            }

        }
    }


    private void flip()
    {
        isHeFacingRight = !isHeFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
