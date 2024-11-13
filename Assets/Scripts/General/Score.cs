using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI _text; 
    public float currentTime;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        if(!gameManager.isCountOn) { 
            return;
        } 
        else {
        currentTime += 1 * Time.deltaTime;
        if (currentTime >= 1) {
            GameManager.score += 1;
            currentTime = 0;
        }
        _text.text = "Score: " + GameManager.score;
        }
    }
}
