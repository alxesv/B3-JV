using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI _text; 
    public float currentTime;
    public bool scoreCountOn = false;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        currentTime = 0f;
        scoreCountOn = true;
    }

    void Update()
    {
        if(!scoreCountOn || gameManager._isOver) {
            return;
        }
        currentTime += 1 * Time.deltaTime;
        if (currentTime >= 1)
        {
            GameManager.score += 1;
            currentTime = 0;
        }
        _text.text = "Score: " + GameManager.score;

    }
}
