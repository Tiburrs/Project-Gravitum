using UnityEngine;

public class RifleDamage : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f; 

    public Camera fpsCAM;

    private AudioSource gunsound;
    private float nextTimeToFire = 0f;

    void Update()
    {
        gunsound = GetComponent<AudioSource>();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }  
    }

    void Shoot()
    {
        RaycastHit hit; 
        if (Physics.Raycast(fpsCAM.transform.position, fpsCAM.transform.forward, out hit, range))
        {
            
            gunsound.Play();
            GetComponent<Animation>().Play("GunShot");
        }
    }
}
