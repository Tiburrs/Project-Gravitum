using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject[] spawns;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach(GameObject x in spawns)
            {
                if (x.GetComponent<SpawnEnemy>())
                {
                    x.GetComponent<SpawnEnemy>().Spawn();
                }
            } 
            Destroy(this.gameObject);
        }
       
    }
}
