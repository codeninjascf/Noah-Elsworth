using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

pubic enum LevelType
{
    Time,
    Moves
}

public class Level : MonoBehaviour
{
    public LevelType type;

    public int levelCondition;
    public int firstStar;
    public int secondStar;
    public int thirdStar;
    // Start is called before the first frame update
    private string _levelName;

    public int MovesRemaining { get; set; }
    public double TimeRemaining { get; set; }
    public int HighScore { get; set; }

    public bool GameOver => type == LevelType.Moves && MovesRemaining <= 0
        || type == LevelType.Time && TimeRemaining <= 0;
    public int StarsAchieved(int score) => Convert.ToInt32(score >= firstStar) +
        Convert.ToInt32(score >= secondStar) + Convert.ToInt32(score >= thirdStar);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
