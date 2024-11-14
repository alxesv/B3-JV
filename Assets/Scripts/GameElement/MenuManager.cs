using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void mainLevel(){
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}