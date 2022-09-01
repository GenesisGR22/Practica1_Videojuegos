using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce = 10;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_WALK = 1;
    private const int ANIMATION_RUN = 2;
    private const int ANIMATION_ATTACK = 3;
    private const int ANIMATION_JUMP = 4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetInteger("Estado", ANIMATION_IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5,rb.velocity.y);
            anim.SetInteger("Estado", ANIMATION_WALK);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            anim.SetInteger("Estado", ANIMATION_WALK);
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey("x"))
        {
            rb.velocity = new Vector2(10,rb.velocity.y);
            anim.SetInteger("Estado", ANIMATION_RUN);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey("x"))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            anim.SetInteger("Estado", ANIMATION_RUN);
            sr.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce( new Vector2(rb.velocity.x, 30f),ForceMode2D.Impulse);
            anim.SetInteger("Estado", ANIMATION_JUMP);
        }
        
        if (Input.GetKeyUp("z"))
        {
            anim.SetInteger("Estado", ANIMATION_ATTACK);
        }
    }
}
