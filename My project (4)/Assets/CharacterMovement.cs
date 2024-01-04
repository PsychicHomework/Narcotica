using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D pbody;
    public float jumpForce = 10f;
    public float maxSpeed = 10f;

    public float maxSpeedy = 15f;
    
    public float maxSpeedup = 15f;
    public float friction = 10f;
    public float playerSpeed = 10f;
    public float airjumps;
    public float airjumpmax = 5;
    public float velocity_y;
    public float velocity_x;
    public bool check;
    public bool walljumping;
    public playermomentum pm;

    



    public groundcheck GC;

    public wallcheck WC;

    private SpriteRenderer player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        pbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    async void Update()
    {
        if (GC.airjumpfill == true)
        {
            airjumps = airjumpmax;
        }
          // airjump
        if (airjumps > 0 && Input.GetKeyDown(KeyCode.Space) && GC.grounded == false)
        {
            pbody.AddForce(transform.up * jumpForce * 2);
            airjumps -= 1;
        }


        //walljump
        if (WC.canwalljump == true && (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 ))
        {
            maxSpeedy = 2f;

            //wall on left
            if (Input.GetKeyDown(KeyCode.Space) && (Input.GetAxis("Horizontal") < 0))
            {
                walljumping = true;
                pbody.velocity = new Vector3(20,(20 + pm.momentum * 5));
                await WallJumpCheck();
                walljumping = false;
                playerSpeed = 50f + (pm.momentum * 2);
                await WallJumpCheck();
                playerSpeed = 200f;

            }
            
            //wall on right
            if (Input.GetKeyDown(KeyCode.Space) && (Input.GetAxis("Horizontal") > 0))
            {
                walljumping = true;
                pbody.velocity = new Vector3(-20,30);
                await WallJumpCheck();
                walljumping = false;
                playerSpeed = 50f;
                await WallJumpCheck();
                playerSpeed = 200f;


            }

        }
        else maxSpeedy = 15f;
        

        //wallslide wall on right



//magnitude of speed
        velocity_y = pbody.velocity.y;
        velocity_x = Mathf.Abs(pbody.velocity.x);

//y speed Limiter
        if (velocity_y < -maxSpeedy)
        {
            pbody.velocity = Vector3.ClampMagnitude(pbody.velocity, maxSpeedy);
        }

        if (velocity_y > maxSpeedup)
        {
            pbody.velocity = Vector3.ClampMagnitude(pbody.velocity, maxSpeedup);
        }



                // horizontal movement right
        if (Input.GetAxis("Horizontal") > 0 && walljumping == false)
        {
            pbody.AddForce(transform.right * playerSpeed * Time.deltaTime * 65);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // horizontal movement left
        if (Input.GetAxis("Horizontal") < 0 && walljumping == false)
        {
            pbody.AddForce(transform.right * -playerSpeed * Time.deltaTime * 65);
            GetComponent<SpriteRenderer>().flipX = true;
        }



    }

    private static async Task WallJumpCheck()
    {
        await Task.Delay(200);
    }

    void FixedUpdate()
    {


        // jump
        if (GC.grounded == true && Input.GetKey(KeyCode.Space))
        {
            pbody.AddForce(transform.up * jumpForce);
        }
//X speed limiter
        if(pbody.velocity.x > (maxSpeed + pm.momentum))
        {
	        pbody.velocity = new Vector2((maxSpeed + pm.momentum), pbody.velocity.y);
        }
        if(pbody.velocity.x < (-maxSpeed - pm.momentum))
        {
	        pbody.velocity = new Vector2((-maxSpeed - pm.momentum), pbody.velocity.y);
        }
    }
}
