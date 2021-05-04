using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuff : MonoBehaviour
{

    public GameObject[] buffs;

    public void spawnBuff(Transform point)
    {
        int rand = Random.Range(0, buffs.Length);
        Instantiate(buffs[rand], point.position+(Vector3.up*.5f), Quaternion.identity);
    }
}
