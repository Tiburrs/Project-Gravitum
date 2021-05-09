using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProj : MonoBehaviour
{
    public float speed;
    public float firerate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.name.Contains("Bullet"))
        {
            // Debug.Log(collision.collider.gameObject.name);
            if (collision.collider.gameObject.tag == "Player")
            {
                collision.collider.gameObject.GetComponent<playerScript>().takeDamage(1000);

            }
            speed = 0;
            Destroy(gameObject);
        }
    }
}
