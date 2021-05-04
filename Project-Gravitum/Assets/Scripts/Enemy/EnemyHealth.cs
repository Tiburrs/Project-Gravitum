using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp=100;
    public bool dead=false;
    private Animator animate;
    private SpawnBuff sb;
    private void Awake()
    {
        sb = this.GetComponent<SpawnBuff>();
        animate = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (dead)
        {
            animate.SetInteger("State", 8);
            Death();
        }
    }
    // Start is called before the first frame update
    public void takeDamage()
    {       
        hp -= 20;
            if (hp > 0)
            {
               
                Debug.Log(hp);
            }
            else
            {
            dead = true;
            }
       
    }

    public void Death()
    {
        Destroy(transform.parent.gameObject, 5f);
    }

    private void OnDestroy()
    {
        sb.spawnBuff(this.transform);
        Debug.Log(this.name);
    }
}
