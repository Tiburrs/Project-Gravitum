using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Text jumpcount;
    public Text resist;
    public Text movespeed;
    public TMP_Text timer;
    public TMP_Text kill;

    public void SetMaxHealth(int max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
    public void UpdateHealth(int hp)
    {
        slider.value = hp;
    }

    public void UpdateJC(int jump)
    {
        jumpcount.text = "x" + jump;
    }

    public void UpdateAR(int res)
    {
        resist.text = res+"%"; 
    }

    public void UpdateMS(int speed)
    {
        movespeed.text = "x" + speed;
    }


    private float timeRemaining = 300;
    public bool timerIsRunning = false;
    int buildIndex;
    public GameObject pause;
    public LookAround control;
    public Animator scene;
    public Image fade;
    public SceneController sc;
    bool show;
    private void Start()
    {
        show = false;
        // Starts the timer automatically
        timerIsRunning = true;
        control = this.GetComponent<LookAround>();
        sc = GameObject.FindGameObjectWithTag("SC").GetComponent<SceneController>();
        Scene currentScene = SceneManager.GetActiveScene();
         buildIndex = currentScene.buildIndex;
        Time.timeScale = 1;
    }

    void Update()
    {
        DisplayKillCount();
        if (timerIsRunning)
        {   
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                sc.ChangeScene(2);
            }
        
        
        }
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex != buildIndex)
        {
            timeRemaining = 200;
            timerIsRunning = true;
            buildIndex = currentScene.buildIndex;
            scene.SetTrigger("Return");
           // Debug.Log(buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                show = !show;
                pause.SetActive(show);
                control.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                renablemove();
            }

        }
        
    }

    public void renablemove()
    {
        show = !show;
        pause.SetActive(show);
        control.enabled = true;


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void DisplayKillCount()
    {
        if(buildIndex==1)
        kill.text = GameState.count + "/" + (GameState.enemygoal / 2);

        else
        {
            kill.text = GameState.count + "/2" ;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }

    public void AccessSceneR()
    {
        sc.reload();
    }

    public void AccessTrans(int n)
    {
        GameState.transitioning = true;
        sc.ForceReturn(n);
    }
}

