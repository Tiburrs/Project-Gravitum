using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGravity : MonoBehaviour
{
   
    [SerializeField] private Rigidbody rb;
    public float range = 100f;

    public playerScript player;


    public Camera fpsCAM;
    public RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            Shoot();
            
        }
    }

    private void OnDisable()
    {
        hit = new RaycastHit();
    }
    private void FixedUpdate()
    {   /*
        if (hit.normal.y < 0)
        {
            gravityUP();
        }
        if(hit.normal.y > 0)
        {
            gravityNormal(); 
        }
        if(hit.normal.x > 0)
        {
            gravityLeft();
        }
        if (hit.normal.x < 0)
        {
            gravityRight();
        }
        else
            rb.useGravity = true; */

        gravityTest();
    }

    void Shoot()
    {

        if (Physics.Raycast(fpsCAM.transform.position, fpsCAM.transform.forward, out hit, range))
        {
            Debug.Log(hit.normal);


            GetComponent<Animation>().Play("GunShot");
        }


    }

    void gravityTest()
    {
        rb.useGravity = false;
        Debug.Log("gravity test");
        player.ApplyGravity(hit.normal * (-9.8f) * 10);
    }
    /*
        void gravityNormal()
    {
        
        player.ApplyGravity(new Vector3 (0, -30f, 0));

    }
    void gravityLeft()
    {
        
        player.ApplyGravity(new Vector3(-30f, 0, 0));

    }
    void gravityRight()
    {
        
        player.ApplyGravity(new Vector3(30f, 0, 0));
    }

    void gravityUP()
    {
 
        player.ApplyGravity(new Vector3(0, 30f, 0));
    }*/
}
