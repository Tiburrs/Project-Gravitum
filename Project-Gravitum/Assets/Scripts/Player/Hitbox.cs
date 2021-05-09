using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void Start()
    {
      
    }
   
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            
            other.GetComponent<EnemyHealth>().takeDamage(.3f);
           
        }
    }
    
}
