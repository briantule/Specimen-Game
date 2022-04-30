using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    float maxTime;
    float timer;
    float total;

    // int colorRand;
    // int tracklast;
    // int odds;

    // Color greenC = new Color(0.247f, 1.000f, 0.000f, 1f);
    // Color pinkC = new Color(0.894f, 0.082f, 0.976f, 1f);
    // Color blueC = new Color(0.035f, 0.984f, 1.000f, 1f);
    // Color yellowC = new Color(1.000f, 0.949f, 0.000f, 1);
    // Color purpleC = new Color(0.7019608f,0.3490196f,0.9803922f,1f);
    // Color whiteC = new Color(1f,1f,1f,1f);

    public GameObject obstacle1;
    // public GameObject obstacle2;
    // SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        total = 0;
        maxTime = 2f;
        // tracklast = 0;
    }

    // Update is called once per frame
    void Update()
    {
        total += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer >= maxTime){
            GenerateObstacle();
            timer = 0;
            // if(total >= 30f){
            //     GenerateObstacle2();
            // }
        }
    }

    void GenerateObstacle(){
        GameObject newObstacle = Instantiate(obstacle1);
        // sr = newObstacle.GetComponent<SpriteRenderer>();
        // var colors = new Color[] {yellowC, blueC, greenC, pinkC};
        // colorRand = Random.Range(0,4);
        // if(colorRand == tracklast){
        //     colorRand = (colorRand+1)%4;
        // }
        // tracklast = colorRand;
        // sr.color = colors[colorRand];
    }

    // void GenerateObstacle2(){
    //     odds = Random.Range(0,3);
    //     if(odds == 0){
    //         GameObject newObstacle = Instantiate(obstacle2);
    //         sr = newObstacle.GetComponent<SpriteRenderer>();
    //         var colors = new Color[] {purpleC, whiteC};
    //         colorRand = Random.Range(0,2);
    //         sr.color = colors[colorRand];
    //         if(colorRand == 1){
    //             newObstacle.transform.position = new Vector2(13.51f, -3.398f);
    //         }
    //     }
    // }
}
