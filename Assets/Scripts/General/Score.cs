using System.Collections;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI _text; 
    public float currentTime;
    public TextMeshProUGUI bonusText;

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
            if (currentTime >= 0.1) {
                GameManager.score += 1;
                currentTime = 0;
            }
            _text.text = "Score: " + GameManager.score;

            if (SaltItem.isBonusSalt) {
                bonusText.text = "+ " + SaltItem.saltPoint;
                StartCoroutine(HideBonusTextAfterDelay());
            }
        }
    }

    private IEnumerator HideBonusTextAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        bonusText.text = "";
        SaltItem.isBonusSalt = false;
    }
}