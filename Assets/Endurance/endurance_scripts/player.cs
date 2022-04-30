using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool isJumping;
    int level = 0; //GET FROM SPECIMEN DATA
    int endurance = 10; //GET FROM SPECIMEN DATA
    int lives;
    public static int targetTime;
    public specimen2 spec;

    public GameManager gameManager;
    AudioSource jumpSound;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {  
        // specimen2 specimen = this.GetComponent<specimen2>();
        spec.LoadPlayer();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        isJumping = false;
        jumpSound = GetComponent<AudioSource>();
        StartCoroutine(setValues());
    }

     // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey("space") && isJumping == false){
            jumpy();
        }
    }

    private void jumpy(){
            rb.velocity = new Vector3(0, 20, 0);
            isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(isJumping == true){
            isJumping = false;
            jumpSound.Play();
        }
    }

    public int getCurrentLives(){
        return lives;
    }

    public int getTargetTime(){
        return targetTime;
    }

    IEnumerator setValues(){
        yield return new WaitForSeconds(1);
        endurance = spec.endurance;
        level = spec.getLevel();
        targetTime = level * 8;
        lives = endurance/10 + 1;
        timer = 0;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        // if((collision.gameObject.GetComponent<SpriteRenderer>().color == purpleC)){
        //     jumpy();
        // }
        if(collision.tag == "obstacles"){
            lives -= 1;
            if(lives == 0){
                gameManager.GameOver();
                if(timer >= targetTime){
                    Results.setXPGained(50);
                    Results.setEnduranceGained(5);
                    Results.setCurrencyGained(20);
                }
                else if(timer < targetTime){
                    Results.setXPGained(-25);
                    Results.setEnduranceGained(-2);
                    Results.setCurrencyGained(0);
                }
                //StartCoroutine(ShowResultsScreen(3.0f));
            }
        }
    }

    // public IEnumerator ShowResultsScreen(float t)
    // {
    //     yield return new WaitForSeconds(t);
    //     //specimen.SavePlayer(); 
    // }
}
