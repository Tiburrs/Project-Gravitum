using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    private AudioSource gunsound;
    // Start is called before the first frame update
    void Start()
    {
        gunsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gunsound.Play();
            GetComponent<Animation>().Play("GunShot");
        }

    }
}
