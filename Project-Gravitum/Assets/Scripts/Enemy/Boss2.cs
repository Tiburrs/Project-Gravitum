using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject player;
    private Transform mtransform;
    public Transform barrel;
    public Transform[] bspawn;
    public GameObject effect;
    public ParticleSystem flare;
    public float rotate = .2f;
    public float delay = .5f;
    float shoot;
    float atkspeed, cooldown;
    bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        attacking = true;
        shoot = delay;
        cooldown = 3;
        atkspeed = cooldown;
        player = GameObject.FindGameObjectWithTag("Player");
        mtransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 look = player.transform.position - barrel.position;
        Quaternion rot = Quaternion.LookRotation(look);

        mtransform.rotation = Quaternion.Slerp(mtransform.rotation, rot, rotate * Time.deltaTime);//Debug.Log(mtransform.eulerAngles.x);
        if (transform.eulerAngles.x < 330 && mtransform.eulerAngles.x > 280)
        {
            
            mtransform.eulerAngles = new Vector3(325, mtransform.eulerAngles.y, mtransform.eulerAngles.z);
        }
        if (attacking&&shoot<0)
        {
            flare.Play();
            Shoot();
            shoot = delay;
            
        }
        if (atkspeed < 0)
        {
            flare.Pause();
            attacking = !attacking;
          
            atkspeed = cooldown;
        }
        atkspeed -= Time.deltaTime;

        shoot -= Time.deltaTime;
            

        
       
    }
    public void Shoot()
    {
        GameObject vfx;

        if (barrel != null)
        {
            foreach (Transform b in bspawn)
            {
                vfx = Instantiate(effect, b.position, Quaternion.identity);
                vfx.transform.localRotation = b.rotation;
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
    
}
