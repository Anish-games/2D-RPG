using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jump;
    private float moveInput;

    private bool isHeFacingRight = true;

    private bool isHeGrounded;
    public Transform GroundCheck;
    public float radiusOfCircle;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;

    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        isHeGrounded = Physics2D.OverlapCircle(GroundCheck.position, radiusOfCircle, whatIsGround);


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


    private void Update()
    {
        if (isHeGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && extraJump > 0)
        {
            rb.linearVelocity = Vector2.up * jump;
            extraJump--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && extraJump == 0 && isHeGrounded == true)
        {
            rb.linearVelocity = Vector2.up * jump;

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
