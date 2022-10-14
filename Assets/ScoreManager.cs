using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject controls;
    public float controlDisappear = 3f;

    public float scoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controlDisappear -= Time.deltaTime;
        if (controlDisappear <= 0)
        {
            controls.SetActive(false);
        }

        scoreCount += pointsPerSecond * Time.deltaTime;


        scoreText.text = "Score: " + Mathf.Round (scoreCount);

    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
