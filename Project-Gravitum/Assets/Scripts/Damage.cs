using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageAmount = 50;
    public float TargetDistance;
    


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
               if (hit.transform.tag == "Enemy")
               {
                    hit.transform.GetComponent<EnemyHealth>().takeDamage(DamageAmount);
               }

                
            }
        }
    }
}