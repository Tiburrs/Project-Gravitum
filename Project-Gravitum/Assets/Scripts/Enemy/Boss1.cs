using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject player;
    private Transform mtransform;
    public Transform barrel;
    public LineRenderer laser;
    float atkspeed, cooldown;
    bool attacking = false; 
    Vector3 range;
    public float rotate = .2f;
    // Start is called before the first frame update
    void Start()
    {
        laser.gameObject.SetActive(true);
        cooldown = 3;
        atkspeed = cooldown;
        player = GameObject.FindGameObjectWithTag("Player");
        mtransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {

            Vector3 look = player.transform.position - barrel.position;
            Quaternion rot = Quaternion.LookRotation(look);

            mtransform.rotation = Quaternion.Slerp(mtransform.rotation, rot, rotate * Time.deltaTime);
            if (mtransform.eulerAngles.x < 90 && mtransform.eulerAngles.x > 20)
            {
                // Debug.Log(mtransform.eulerAngles.x);
                mtransform.eulerAngles = new Vector3(20, mtransform.eulerAngles.y, mtransform.eulerAngles.z);
            }
            RaycastHit hit;

            if (Physics.Raycast(barrel.position, barrel.forward, out hit))
            {range = hit.point;
                laser.gameObject.SetActive(true);
                laser.SetPosition(0, barrel.position);
                laser.SetPosition(1, range);
                if (hit.transform.tag == "Player")
                {
                    
                   // Debug.Log(hit.point);

                    

                }
            }
        }
    }

    IEnumerator transition()
    {
       
        yield return new WaitForSeconds(6);
        
    }


}

