using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hp=100;
    public bool dead=false;
    private Animator animate;
    private SpawnBuff sb;
    GameState gs;
    bool closing = false;
    public bool spawnable;
    private void Awake()
    {   
        gs = GameObject.FindGameObjectWithTag("GameC").GetComponent<GameState>();
        sb = this.GetComponent<SpawnBuff>();
        if(this.GetComponent<Animator>())
        animate = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (dead)
        {   if(this.GetComponent<Animator>())
            animate.SetInteger("State", 8);
            Death();
        }
    }
    // Start is called before the first frame update
    public void takeDamage(float hit)
    {       
        hp -= hit;
            if (hp > 0)
            {
               
               // Debug.Log(hp);
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
        //Debug.Log(GameState.spawn);
        if (GameState.spawn && spawnable)
        {
           gs.trackgoal(); 
            sb.spawnBuff(this.transform);
        }
        else if(!spawnable)
        {
            gs.trackboss();
        }
        
      //  Debug.Log(this.name);
    }

    private void OnApplicationQuit()
    {
        closing = true;
    }
}
