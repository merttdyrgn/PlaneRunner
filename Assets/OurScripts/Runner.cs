using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private float interpFactor;
    
    //Public bool is grounded
    private float jumpSpeed = 0.0f;
    private float jumpMax = 10.0f;
    private float jumpCooldown = 0.0f;
    
    private CharacterController controller;
    private Vector3 motor;
    private Vector3 rotate;

    private int speed = 10;
    private float verticalVelocity = 0.0f;
    private float gravity = 6.0f;

    private float animationDuration = 2.0f;
    private float startTime;

    private bool isDead = false;

    private float scoreUp = 100.0f;

    public GameObject cooldownUI;

    public AudioSource planeSound;
    public AudioSource crashSound;
    public AudioSource coinSound;
    public AudioSource gameMusic;
    

    // Start is called before the first frame update
    void Start()
    {
        planeSound.Play();
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        cooldownUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            gameMusic.Stop();
            planeSound.Stop();
            cooldownUI.SetActive(false);
            return;
        }
            
        
        if(jumpCooldown>0)
            cooldownUI.SetActive(false);
        else
            cooldownUI.SetActive(true);
        
        motor = Vector3.zero;
        //isGrounded = controller.isGrounded;
       
        if (jumpCooldown > 0)
            jumpCooldown -= Time.deltaTime;

        if (jumpCooldown < 0)
            jumpCooldown = 0.0f;
        if (controller.isGrounded && Input.GetButton("Jump") && jumpCooldown == 0)
        {
            interpFactor = 0.01f;
            jumpCooldown = 8.0f;
        }

        if (interpFactor != 0 && interpFactor < 1)
        {
            jumpSpeed = Mathf.Lerp(0, jumpMax, interpFactor);
            motor.y = jumpSpeed;
            interpFactor += 0.2f;
        }

        if (Time.time - startTime <= animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        
        
        //X: Left-Right
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            if (controller.transform.position.x > -3)
            {
                motor.x -= 10.0f;
            }
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            if (controller.transform.position.x < 3)
            {
                motor.x += 10.0f;
            }
        }

        //Y: Up-Down
        motor.y = motor.y - (gravity * Time.deltaTime);

        //Z: Forward-Backward
        motor.z += speed * Time.deltaTime;

        controller.Move(motor);
    }
    
    public void setSpeed(int accelerate)
    {
        speed += accelerate;
    }

    public int getSpeed()
    {
        return speed;
    }

    public Vector3 getPos()
    {
        return motor;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle" || controller.transform.position.y < -10)
                {
                   crashSound.Play();
                    gameOver();
                }
        if (hit.gameObject.tag == "Point")
                {
                    GetComponent<Score>().setScore(scoreUp);
                    coinSound.Play();
                    Destroy(hit.gameObject);
                }
    }

    void gameOver()
    {
        isDead = true;
        GetComponent<Score>().gg();
        
    }
    
    public float getJumpCooldown()
    {
        return jumpCooldown;
    }
}
