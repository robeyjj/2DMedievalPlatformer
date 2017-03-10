using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

    //Rigidbody 2D
    public Rigidbody2D characterRigidBody;

    //Boolean to check direction Character is facing
    bool isCharacterFacingRight = true;  

    //Animator
    Animator characterAnimator;

    //Character vars
    public float jumpForce = 400f;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float speed = 5f;

    //Arrow vars
    public GameObject archerArrow;   
    public Transform arrowSpawn;
    Vector3 newArrowTransformPosition = new Vector3(0, 0, 0);    
    public Rigidbody2D arrowRigidBody;
    public BoxCollider2D arrowBoxCollider2D;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;   
    public int arrowForce = 1000;
    bool isShooting = false;
    public AudioClip shootSound;
    public AudioSource source;
    private float volumeLevel = 0.3f;

    // Use this for initialization
    void Start () {
        characterAnimator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        arrowSpawn.position += newArrowTransformPosition;        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        characterAnimator.SetBool("Ground", grounded);
        
        //Get Keyboard input
        float characterMovement = Input.GetAxis("Horizontal");       
        
        //Speed to move Character
        characterAnimator.SetFloat("Speed", Mathf.Abs(characterMovement));

        //Change Velocity based on speed and direcitonal movement
        characterRigidBody.velocity = new Vector2(characterMovement * speed, characterRigidBody.velocity.y);
        //characterRigidBody.velocity = new Vector2(characterMovement * speed, 0.0f);

        //Check to flip character direction
        if (characterMovement > 0 && !isCharacterFacingRight)
        {
            FlipAnimation();
        }
        else if(characterMovement < 0 && isCharacterFacingRight)
        {
            FlipAnimation();
        }        
    }

    //Update is called once per frame
    void Update()
    {
        
        //Check for Spacebar to initiate Jump
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            characterAnimator.SetBool("Ground", false);            
            characterRigidBody.AddForce(new Vector2(0, jumpForce));           
        }
        
        //Check for "Enter/Return" key or LftCtrl to fire an arrow
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.LeftControl))
        {
            isShooting = true;            
            FireArrow();            
        }
        //isShooting = false;
        if (groundCheck.transform.position.y < -7.0f)
        {

        }        
    }

    void FlipAnimation()
    {
        //Set Character facing direction to facing left or right
        isCharacterFacingRight = !isCharacterFacingRight;
        Vector3 currentScale = transform.localScale;
        //Flip direction of character
        currentScale.x *= -1;
        transform.localScale = currentScale;

        //Flip Arrows
        Vector3 archerScale = archerArrow.transform.localScale;
        archerScale.x *= -1;
        arrowForce *= -1;
        archerArrow.transform.localScale = archerScale;
    }

    void FireArrow()
    {
        if (Time.time > fireRate + lastShot)
        {                   
            //Instantiate a new Clone of an arrow GameObject
            GameObject archerArrowObject = (GameObject)Instantiate(archerArrow, arrowSpawn.position, arrowSpawn.rotation);
            arrowRigidBody = archerArrowObject.GetComponent<Rigidbody2D>();
            arrowBoxCollider2D = archerArrowObject.GetComponent<BoxCollider2D>();
            source.PlayOneShot(shootSound, volumeLevel);


            archerArrowObject.layer = 12;
            archerArrowObject.tag = "arrowTag";

            //Add velocity to arrow            
            arrowRigidBody.AddForce(new Vector2(arrowForce, 0));
            arrowBoxCollider2D.isTrigger = false;

            //Reset time since last shot
            lastShot = Time.time;

            //Destroy the arrow so it doesn't fly forever off screen
            Destroy(archerArrowObject, 3.0f);
        }
        else
        {
            return;
        }
        
    } 
}
