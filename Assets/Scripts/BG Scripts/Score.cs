using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 2;
    private float score = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToNextLevel)
            LevelUp();
        score += Time.deltaTime * difficultyLevel;
    
    }


    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<BGMover>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }



}
