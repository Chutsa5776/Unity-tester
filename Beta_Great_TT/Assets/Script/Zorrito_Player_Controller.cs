using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private float horizontal;
    private float speed = 1.5f;

    private bool isjumping;
    private bool LookRight = true;


    public float jump;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animacion")]

    private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");  

        if (Input.GetButtonDown("Jump") && !isjumping )
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isjumping = true;

            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f )
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


         Vector2 position = transform.position;
         position.x = position.x + 3f * horizontal * Time.deltaTime;
        transform.position = position;

        animator.SetFloat("Caminar_Lados",Mathf.Abs(horizontal));  

        Flip();    

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Onlanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }
    private void Flip()
    {
        if (LookRight && horizontal < 0f || !LookRight && horizontal > 0f)
        {
            LookRight = !LookRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
