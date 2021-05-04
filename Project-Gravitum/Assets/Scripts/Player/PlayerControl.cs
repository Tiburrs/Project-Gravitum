using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movespeed=5;
    public int jumpamount=1;
    public float damagereduc=0;
    public float firespeed=1;
    Transform player;
    CharacterController pc;
    float xrotate = 0f;
    float yrotate = 0f;
    float sensitivity = 100;
    public float reduct = 1f;
    // Start is called before the first frame update
    void Start()
    {   Cursor.lockState = CursorLockMode.Locked;
        pc = this.GetComponent<CharacterController>();
        player = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       float horiz =  Input.GetAxis("Horizontal");     float mx = Input.GetAxis("Mouse X") * Time.deltaTime * 400;
        float verti =  Input.GetAxis("Vertical");      float my = Input.GetAxis("Mouse Y") * Time.deltaTime * 400;

        Vector3 move = player.right * horiz + player.forward * verti;
        pc.Move(move * movespeed * Time.deltaTime);
        
        xrotate -= my;
      xrotate = Mathf.Clamp(xrotate, -90f, 90f);
        yrotate += mx;/*
        player.localRotation = Quaternion.Euler(xrotate, yrotate, 0f);
        player.Rotate(Vector3.up * mx);*/
       
        transform.localEulerAngles = new Vector3(xrotate % 360, yrotate % 360, 0);

    }

    private void FixedUpdate()
    {
           
    }
    public void buffMS()
    {
        if (movespeed < 20)
        {
            movespeed = movespeed * (1 + reduct);
            reduct *= .6f;
        }
        else
        {
            movespeed+=.01f;
        }
    }
    public void buffJ()
    {

    }
    public void buffAS()
    {

    }
    public void buffDR()
    {

    }
}
