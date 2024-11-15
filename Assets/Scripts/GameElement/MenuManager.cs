using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI _title;

    public void mainLevel(){
        SceneManager.LoadScene("MainScene");
    }

    void Start() {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        Color[] predefinedColors = {
            new Color(0f, 0.96f, 0.87f),
            new Color(0.09f, 0.94f, 0.02f),
            new Color(0.94f, 0.05f, 0.1f),
            new Color(0.96f, 0.92f, 0f),
            new Color(0.77f, 0f, 0.93f),
            new Color(0.99f, 0.63f, 0f)
        };

        while (true)
        {
            Color chosenColor;

            if (Random.value > 0.5f)
            {
                chosenColor = predefinedColors[Random.Range(0, predefinedColors.Length)];
            }
            else
            {
                chosenColor = new Color(
                    Random.Range(0.8f, 1f),
                    Random.Range(0.8f, 1f),
                    Random.Range(0f, 0.3f)
                );
            }

            _title.color = chosenColor;

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void macheteLevel(){
        SceneManager.LoadScene("MacheteLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
