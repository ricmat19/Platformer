using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float movement = 10f;
    [SerializeField]
    private float attackForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    private float movementX;
    private bool attack;
    private bool onGround;
    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private string Run_Animation = "Run";
    private string Attack_Animation = "Attack";
    private string Hit_Animation = "Hit";

    private string Ground_Tag = "Ground";

    
    // Awake is called immediately upon game initiallizaton
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatePlayer();
        PlayerRun();
        PlayerAttack();
    }

    private void FixedUpdate(){
        PlayerJump();
    }

    void AnimatePlayer(){
        //Triggers the player's Run animation
        if(movementX >  0){
            animator.SetBool(Run_Animation, true);
            spriteRenderer.flipX = false;
        //Triggers the player's Run animation
        } else if( movementX < 0){
            animator.SetBool(Run_Animation, true);
            spriteRenderer.flipX = true;
        //Triggers the player's Idle animation
        }else{
            animator.SetBool(Run_Animation, false);
        }
    }

    void PlayerRun(){
        // animator.SetBool(Hit_Animation, false);
        //Checks if moving left (-1) or right (1)
        movementX = Input.GetAxisRaw("Horizontal");
        //Moves the player left and right
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movement;
    }

    void PlayerAttack(){
        // animator.SetBool(Hit_Animation, false);
        if(Input.GetButton("Fire1")){
            animator.SetBool(Attack_Animation, true);
        }else{
            animator.SetBool(Attack_Animation, false);
        }
    }

    void PlayerJump(){
        // animator.SetBool(Hit_Animation, false);
        if(Input.GetButtonDown("Jump") && onGround){
            onGround = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    //Checks fo a Collision between the class object and another asset
    private void OnCollisionEnter2D(Collision2D collision){
        //Checks is the player has collided with the ground
        if(collision.gameObject.CompareTag(Ground_Tag)){
            onGround = true;
        }

        //Checks if the player has collided with something other than the ground
        if(!collision.gameObject.CompareTag(Ground_Tag)){
            animator.SetBool(Hit_Animation, true);
        }
    }

}
