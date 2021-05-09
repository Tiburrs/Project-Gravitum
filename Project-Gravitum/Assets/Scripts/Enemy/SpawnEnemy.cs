using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemytype;
    public int enemycount;
    private void Awake()
    {
        GameState.enemygoal += enemycount;
    }
    public void Spawn()
    {
        Vector3 SpawnLoc = transform.position;
        for(int i =0; i<enemycount; i++)
        {
            Instantiate(enemytype, SpawnLoc, Quaternion.identity);

        }

        Destroy(this.gameObject);
    }

}
