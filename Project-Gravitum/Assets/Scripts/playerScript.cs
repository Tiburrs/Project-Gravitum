using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 100f;
    
    


    [SerializeField] private float jumpForce = 10f;


    [SerializeField] private float groundDrag = 4f;
    [SerializeField] private float airDrag = 1f;

    [SerializeField] private bool inverseGravity;

    [SerializeField] KeyCode jumpKey = KeyCode.Space; 

   
    float playerHeight = 2f;

    float inputX;
    float inputY;
    Vector3 moveDirection;
    bool isGrounded;
    int jcount;
    int maxjumps = 1;
    int speedcollect = 0;
    public int reduction = 2;
    public int maxhealth = 10000;
    public int health;
    bool alive;
    public GameObject checkGrav;
    bool playingdeath;
    public AudioSource death;
    public AudioClip[] clips;
    public LookAround disable;
    SceneController sc;
   
    PlayerUI ui;

    void Start()
    {
        health = maxhealth;
        disable = this.GetComponent<LookAround>();
        death = this.GetComponent<AudioSource>();
        playingdeath = false;
        alive = true;
        ui = this.GetComponent<PlayerUI>();
        jcount = maxjumps;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        sc = GameObject.FindGameObjectWithTag("SC").GetComponent<SceneController>();
        ui.SetMaxHealth(maxhealth);
       
        
        // playerGravity = rb.gravity;
    }

   

    void Update()
    {

        if (alive)
        {

            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + .2f);

            if (isGrounded)
            {
                jcount = maxjumps;
            }


            MyInput();
            ControlDrag();
            regen();
            ui.UpdateHealth(health);
            if (Input.GetKeyDown(jumpKey) && jcount > 0)
            {
                Jump();
                jcount--;

            }

            if (checkGrav.activeInHierarchy)
            {
                rb.useGravity = false;
            }
            else
            {
                rb.useGravity = true;
                if (!isGrounded)
                    rb.AddForce(Vector3.down * 10f, ForceMode.Acceleration);
            }
            /*
            if (Input.GetKeyDown(KeyCode.G))
            {
                takeDamage(1000);
            }*/
        }

        else
        {
            if (!playingdeath)
            {
                StartCoroutine(playdeath());
                playingdeath = true;
                disable.enabled = false;
            }
            
        }


    }

    IEnumerator playdeath()
    {
        int random = Random.Range(0, clips.Length);
        death.clip = clips[random];
        death.Play();
        yield return new WaitWhile(() => death.isPlaying);
        sc.ForceReturn(0);
        
    }
    public void takeDamage(int damage)
    {
        float multiplier = ((100f - reduction) / 100f);
       
        float hitdmg = damage * multiplier;
        hitdmg = hitdmg > 1 ? hitdmg : 1;
        health -= (int)hitdmg;
        if (health < 0)
        {
            alive = false;
        }
        ui.UpdateHealth(health);
       // Debug.Log("TakingDamage");
    }

    public void regen()
    {
        if (health < maxhealth) { 
        health++;
        ui.UpdateHealth(health);
    }
    }
    void Jump()
    {  
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
           
        }
        else
        {
            rb.drag = airDrag;
            
        }   
    }
    void MyInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * inputY + transform.right * inputX; 
    }

    void FixedUpdate()
    {
        MovePlayer();
        
    }

    void MovePlayer()
    {
       // Debug.Log("moveDirection");
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
    }

    public void ApplyGravity(Vector3 grav)
    {
       
        //Debug.Log("gravity Normal");
        rb.AddForce(grav.x, grav.y, grav.z, ForceMode.Acceleration);
    }

    public void buffMS()
    {
        speed += 20;
        speedcollect++;
        ui.UpdateMS(speedcollect);
    }
    public void buffJ()
    {
        maxjumps++;
        ui.UpdateJC(maxjumps);
    }
    public void buffDR()
    {
        reduction++;
        ui.UpdateAR(reduction);
    }

}
