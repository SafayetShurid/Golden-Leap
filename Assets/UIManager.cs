using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;


    void Start()
    {
        
    }

   
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString();
    }
}
