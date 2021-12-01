using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [HideInInspector]
    public float movement;
    [SerializeField]
    private float attackForce = 10f;
    [SerializeField]
    private float hit = 10f;

    private float movementX;
    private bool attack;
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
        // animator = GetComponent<Animator>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // AnimateEnemy();
        // EnemyRun();
        // EnemyAttack();
        // EnemyHit();
    }

    void FixedUpdate(){
        myBody.velocity = new Vector2(movement, myBody.velocity.y);
    }

    void AnimateEnemy(){
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

    void EnemyRun(){
        // animator.SetBool(Hit_Animation, false);
        //Checks if moving left (-1) or right (1)
        movementX = Input.GetAxisRaw("Horizontal");
        //Moves the player left and right
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * movement;
    }

    void EnemyAttack(){
        // animator.SetBool(Hit_Animation, false);
        if(Input.GetButton("Fire1")){
            animator.SetBool(Attack_Animation, true);
        }else{
            animator.SetBool(Attack_Animation, false);
        }
    }

    // void EnemyHit(){

    // }

    //Checks fo a Collision between the class object and another asset
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject);
        //Checks if the player has collided with something other than the ground
        if(!collision.gameObject.CompareTag(Ground_Tag)){
            animator.SetBool(Hit_Animation, true);
        }
    }
}
