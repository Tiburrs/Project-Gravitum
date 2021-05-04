using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1,  QueryTriggerInteraction.Ignore))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyHealth>().takeDamage();
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*hit.distance, Color.green);
            Debug.DrawRay(hit.point, hit.normal, Color.yellow);
         //   Debug.Log(hit.transform.name);
        }
    }
}
