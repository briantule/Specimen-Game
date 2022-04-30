using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;
    public GameObject Paused;
    AudioSource dead;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        dead = GetComponent<AudioSource>();
    }

    public void GameOver(){
        Time.timeScale = 0;
        GOPanel.SetActive(true);
        dead.Play();
    }

    void Update(){
        if(Input.GetKeyDown("escape") && GOPanel.activeSelf == false){
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if(Input.GetKey("space") && Paused.activeSelf == false && Time.timeScale == 0){
            Time.timeScale = 1;
            SceneManager.LoadScene("Results");
        }
        // if(Input.GetKey("return") && Paused.activeSelf == true){
        //     Application.Quit();
        // }
    }

    void PauseGame(){
        if(gameIsPaused){
            Time.timeScale = 0f;
            Paused.SetActive(true);
        }
        else{
            Time.timeScale = 1;
            Paused.SetActive(false);
        }
    }
}
