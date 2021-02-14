using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score;
    public float time;
    public bool isGameOver;

    public static GameManager instance;


    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            Debug.Log("GameOver");
        }
    }

    public void ScoreUp()
    {
        score++;
    }

    public void TimeUp()
    {

    }


    public void GameOver()
    {
        isGameOver = true;
    }
}
