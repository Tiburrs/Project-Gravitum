using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    public Animator scene;
    public Image fade;
    // Start is called before the first frame update
    public void ChangeScene()
    {
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        scene.SetTrigger("Transition");
        yield return new WaitUntil(() => fade.color.a == 1);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
