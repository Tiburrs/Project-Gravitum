using UnityEngine;

public class RifleDamage : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 4f; 

    public Camera fpsCAM;

    private AudioSource gunsound;
    private float nextTimeToFire = 0f;
    public Transform startlaser;
    public LineRenderer laser;
    public float timewait=.5f;
    float timer;


    private void Start()
    {
        timer = timewait;
    }
    void Update()
    {
        gunsound = GetComponent<AudioSource>();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {   Shoot();
            nextTimeToFire = Time.time + 2f / fireRate;
            //Debug.Log(nextTimeToFire);
            
            timer = timewait;
        }
        else if(timer<0&&laser.enabled)
        {
            laser.enabled=false;
            timer = timewait;
        
        }    
        timer -= Time.deltaTime;//Debug.Log(timewait);
    }

    void Shoot()
    {  gunsound.Play();
            GetComponent<Animation>().Play("GunShot");
        RaycastHit hit; 
        if (Physics.Raycast(fpsCAM.transform.position, fpsCAM.transform.forward, out hit, range))
        {
            laser.enabled=true;
            laser.SetPosition(0, startlaser.position);
            laser.SetPosition(1, hit.point);
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyHealth>().takeDamage(damage);
            }
          //  Debug.Log(hit.transform.name);
          
        }
    }
}
