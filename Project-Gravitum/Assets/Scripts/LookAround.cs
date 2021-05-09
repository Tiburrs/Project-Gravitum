using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;

    [SerializeField] Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 

    }

    

    // Update is called once per frame
    private void Update()
    {
        myInput();

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    void myInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    }
}
