using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string level = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // private static bool isPaused = false;
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     if(isPaused)
        //     {
        //         Resume();
        //     }
        //     else
        //     {
        //         Pause();
        //     }
        // }
    }

    static int lastSceneIndex;
    public void OpenScene() {
        SceneManager.LoadScene(level);
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(lastSceneIndex);
    }

    // public void Resume()
    // {
    //     pauseMenuUI.SetActive(false);
    //     Time.timeScale = 1f;
    //     isPaused = false;
    //     OpenScene();
    // }

    // void Pause()
    // {
    //     pauseMenuUI.SetActive(true);
    //     Time.timeScale = 0f;
    //     isPaused = true;
    // }
}
