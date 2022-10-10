using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundchecker;
    public LayerMask whatIsGround;

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;

    float maxSpeed = 5.0f;
    bool isOnGround = false;

    public ScoreManager theScoreManager;
   

    public float jumpForce = 400f;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();

        theScoreManager.scoreIncreasing = false;
        theScoreManager.scorecount = 0;
        theScoreManager.scoreIncreasing = true;


    }

    // Update is called once per frame
    void Update()
    {
        //Create a 'float' that will be equal to the players horizontal input
        float movementValueX = 1f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        }
        else
        {
            maxSpeed = 5.0f;
        }
        anim.SetBool("IsOnGround", isOnGround);

        //Change the X velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX*maxSpeed, playerObject.velocity.y);

        //check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundchecker.transform.position, 1.0f, whatIsGround);

        

        //Create a 'float' that will be equal to the players horizontal input
        
        

        //Set movementValueX to 1.0f, so that we always run forward and no longer care about player input

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, jumpForce));
        }

       
    } 
    
    public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "PickUp")
            {
            theScoreManager.scorecount += 10f;
                Destroy(collision.gameObject);
            }
        }
}
