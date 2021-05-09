using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameThrower;

    public GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        flameThrower.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            flameThrower.Play();
            hitbox.SetActive(true);
        }
       

    }
}
