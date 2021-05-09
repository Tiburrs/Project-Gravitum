using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SceneController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.FindGameObjectWithTag("SC").GetComponent<SceneController>();
    }

    // Update is called once per frame
   
    public void Exit()
    {
        sc.Exit();
    }

    public void Play(int i)
    {
        sc.ChangeScene(i);
    }


}
