using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public float bufftype;

    private void OnTriggerEnter(Collider other)
    {
       if (other.transform.tag == "Player")
        {
            Debug.Log(other.transform.name);
            editStats(other.gameObject);
        }
    }


    private void editStats(GameObject player)
    {
        switch (bufftype)
        {
            case 0:
                player.GetComponent<PlayerControl>().buffMS();
                Destroy(this.gameObject);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
