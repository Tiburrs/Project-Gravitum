using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    public Animator scene;
    public Image fade;
    public AudioSource player;
    public AudioClip[] clips;
    public static bool moving=false;
    public bool save;
    int build;
    float timerun;
    private void Start()
    {
        save = false;
        scene = GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>();
        fade = GameObject.FindGameObjectWithTag("Finish").GetComponent<Image>();
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex != build)
            build = currentScene.buildIndex;
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeScene(2);
        }
        switch (build)
        {
            case 0:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                if (save)
                {   save = false;
                    timerun = Time.time - timerun;
                    Debug.Log(timerun);
                    Scoreboards.Scoreboard s = GameObject.FindGameObjectWithTag("board").GetComponent<Scoreboards.Scoreboard>();
                    s.AddEntry(new Scoreboards.ScoreboardEntryData()
                    {
                        time = timerun
                    }); ;
                    
                }
                break;
            case 1:
                timerun = Time.time;
                break;


        }
    }
    // Start is called before the first frame update
    public void ChangeScene(int i)
    {
        switch (i)
        {
            case 0:
                
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>())
                {
                    playerScript test = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();
                    if (test.health > 0)
                    {
                        player.clip = clips[1];
                        StartCoroutine(playAudio(i));
                        save = true;
                    }

                    else
                    {

                    }
                    
                }
           
                break;
            case 1:

                StartCoroutine(transition(i));
                break;
            case 2:
                player.clip = clips[0];
                StartCoroutine(playAudio(i));
                break;
        }
      
  
    }

    public void ForceReturn(int i)
    {
        StartCoroutine(transition(i));
    }

    IEnumerator transition(int i)
    {
        try
        {
            scene.SetTrigger("Transition");
        }
        catch
        {
            scene = GameObject.FindGameObjectWithTag("Finish").GetComponent<Animator>();
            fade = GameObject.FindGameObjectWithTag("Finish").GetComponent<Image>();
            scene.SetTrigger("Transition");
        }
         yield return new WaitUntil(() => fade.color.a == 1);
        if(i!=2)
            destroyplayer();

        
        SceneManager.LoadScene(i);
    }

    IEnumerator playAudio(int i)
    {
        //Debug.Log(i);
        player.Play();
        yield return new WaitWhile(() => player.isPlaying);
        StartCoroutine(transition(i));
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }

    public void reload()
    {
        StartCoroutine(transition(1));
    }

    public void destroyplayer()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
    }

    
}
