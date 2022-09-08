using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float jumpForce = 10;
    //public GameObject InicioCartel;
    //public GameObject FinCartel;
    //private Vector3 startObj;
    //private Vector3 startObjInicio;
    //private Vector3 startObjFin;
    public GameObject Bala;
    public ControlBalaC BalaControlX;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform tr;

    private bool muerte = false;
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_WALK = 1;
    private const int ANIMATION_RUN = 2;
    private const int ANIMATION_ATTACK = 3;
    private const int ANIMATION_JUMP = 4;
    private const int ANIMATION_DEAD = 5;
    private int numSalto = 0;
    private int numBalas = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        //startObjInicio = InicioCartel.transform.position;
        //startObjFin = FinCartel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerte)
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            anim.SetInteger("Estado", ANIMATION_RUN);

            /*if (Input.GetKey(KeyCode.RightArrow))
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
            }*/

            if (Input.GetKeyUp(KeyCode.Space) && numSalto < 2)
            {
                rb.AddForce( new Vector2(rb.velocity.x, 30f),ForceMode2D.Impulse);
                anim.SetInteger("Estado", ANIMATION_JUMP);
                numSalto++;
            }
            
            if (Input.GetKeyUp("z"))
            {
                anim.SetInteger("Estado", ANIMATION_ATTACK);
            }
            if (Input.GetKeyUp("x") && numBalas > 0)
            {
                var BalaPosicion = new Vector3(tr.position.x + 3f, tr.position.y, tr.position.z);
                Instantiate(Bala, BalaPosicion, Quaternion.identity);
                numBalas--;
                BalaControlX.QuitarBala(1);
            }
        }else{
            if (muerte)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_DEAD);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            numSalto = 0;
        }

        /*if (collision.gameObject.CompareTag("Caida"))
        {
            transform.position = startObj ;
        }*/
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            muerte = true;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inicio"))
        {
            startObj = startObjInicio;
        }

        if (collision.gameObject.CompareTag("Fin"))
        {
            startObj = startObjFin ;
        }

    }*/
}

