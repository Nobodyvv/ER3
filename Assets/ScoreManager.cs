using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scorecount;
    public float hiscorecount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scorecount += pointsPerSecond * Time.deltaTime;
        }

        if(scorecount > hiscorecount)
        {
            hiscorecount = scorecount;
        }

        scoreText.text = "Score: " + Mathf.Round(scorecount);
        hiScoreText.text = "Highscore: " + Mathf.Round (hiscorecount);
    }
}
