using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float Score;
    public Text scoreText;
    public Text TopScore;
    public Text currentLives;
    public player Player;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime;
        TopScore.text = "Target time: " + Player.getTargetTime().ToString("000");
        currentLives.text = "Lives: " + Player.getCurrentLives().ToString("00");
        scoreText.text = Score.ToString("000");

    }
}
