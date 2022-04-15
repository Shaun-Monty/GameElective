using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformslayerMask; 
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private SpriteRenderer rend;
    private Transform sprite;
    public Slider slider;

    public EXPStats Evo1 = new EXPStats();

    public float moveSpeed = 0.4f;
    public float jumpHeight =0.4f;


  


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        sprite = GetComponent<Transform>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    { 
    
        moveSpeed = Evo1.GetBounceEXP();
        jumpHeight = Evo1.GetBounceEXP(); 
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

        }

        slider.value = moveSpeed;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Character HIT!!!");
        Evo1.Addexp(0.1f);
        Debug.Log(Evo1.GetBounceEXP());
        if (Evo1.GetBounceEXP()
             > 10)
        {

            rend.color = Color.cyan;
            Debug.Log("Change");
            sprite.transform.localScale = new Vector3(1f, 1f, 1f);



        }

        if(Evo1.GetBounceEXP() > 20)
        {

            rend.color = Color.red;
            Debug.Log("Change");
            sprite.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);


        }

    }


    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.Raycast(cc.bounds.center, Vector2.down, cc.bounds.extents.y + 0.2f, platformslayerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null; 

    }

    



}
