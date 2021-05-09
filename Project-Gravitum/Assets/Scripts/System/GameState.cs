using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int enemygoal;
    public static int count;
    public static bool transitioning;
    public static bool spawn = true;
    public SceneController sc;
    public playerScript test;
    private void Start()
    {
        
        count = 0;
        enemygoal = 0;
        sc = GameObject.FindGameObjectWithTag("SC").GetComponent<SceneController>();
         test = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
           // Debug.Log(enemygoal);
           
        }
        if (test.health < 1)
        {
            setSpawn(false);
        }
        else
        {
            setSpawn(true);
        }
    }

    public static void setSpawn( bool val)
    {
        spawn = val;
    }
    public void trackgoal()
    {
        count++;
        if (count >= (enemygoal/2)&&!transitioning)
        { //Debug.Log(count);
            transitioning = true;
            sc.ChangeScene(2);
        }
    }
    public void trackboss()
    {
        count++;

        if (count > 1&&test.health>0)
        {
            sc.ChangeScene(0);
            
        }
    }

    
}
