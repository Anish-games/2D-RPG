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

    DeathZone deathZone;

    [SerializeField] private int Lives = 100;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();


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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJump > 0)
        {
            rb.linearVelocity = Vector2.up * jump;
            extraJump--;

        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJump == 0 && isHeGrounded == true)
        {
            rb.linearVelocity = Vector2.up * jump;

        }



    }

    private void flip()
    {
        isHeFacingRight = !isHeFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void DamagePlayer()
    {
        Lives--;
        if (Lives <= 0)
        {
            //animator.SetTrigger("Dead");

            enabled = false;
            deathZone.restartLevel();
        }
        else
        {
            //animator.SetTrigger("Hurt");

            
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }



}
