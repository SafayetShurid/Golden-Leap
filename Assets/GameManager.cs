using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public float time;
    public bool isGameOver;

    public AudioSource scoreUpSound;
    public AudioSource backgroundSound;
    public AudioSource gameOverSound;
    public AudioSource railJumpSound;

    public static GameManager instance;


    void Start()
    {
        instance = this;
        if (PlayerPrefs.GetInt("Sound", 1) == 0)
        {
            scoreUpSound.mute = true;
            backgroundSound.mute = true;
            gameOverSound.mute = true;
        }
        else
        {
            scoreUpSound.mute = false;
            backgroundSound.mute = false;
            gameOverSound.mute = false;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            Debug.Log("GameOver");
        }

        time -= Time.deltaTime;

        if(time<=0)
        {
            GameOver();
        }

        
    }

    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    public void ScoreUp()
    {
        score++;
        scoreUpSound.Play();
    }

    public void TimeUp()
    {

    }


    public void GameOver()
    {
        gameOverSound.Play();
        isGameOver = true;
        StartCoroutine(LoadGameOverScene());
    }

    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("LastScore", score);
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        SceneManager.LoadScene(2);

    }

    public void PlayRailJumpSound()
    {
        railJumpSound.Play();
    }
}
