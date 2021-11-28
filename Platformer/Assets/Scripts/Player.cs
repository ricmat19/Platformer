using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float movement = 10f;
    [SerializeField]
    private float attackForce = 11f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private string Run_Animation = "Run";
    private string Attack_Animation = "Attack";

    
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
        //Checks if moving left (-1) or right (1)
        movementX = Input.GetAxisRaw("Horizontal");
        //Moves the player left and right
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movement;
    }

    void PlayerAttack(){
        if(Input.GetButtonDown("Jump")){
            animator.SetBool(Attack_Animation, true);
        }else{
            animator.SetBool(Attack_Animation, false);
        }
    }
}
