using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private bool isKnockedBack = false;
    [SerializeField] private float knockbackForce = 5f;

    private Vector3 knockbackDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isKnockedBack)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("taCorrendo", true);
            }
            else
            {
                animator.SetBool("taCorrendo", false);
            }

            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            if (moveInput > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (moveInput < 0 && isFacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void ApplyKnockback(Vector3 direction)
    {
        isKnockedBack = true;
        knockbackDirection = direction;
        rb.velocity = Vector2.zero;
    }

    void FixedUpdate()
    {
        if (isKnockedBack)
        {
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            isKnockedBack = false; // Desative o knockback após aplicá-lo
        }
    }
}
