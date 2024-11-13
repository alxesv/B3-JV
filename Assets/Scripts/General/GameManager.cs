using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GameOverUI;
    [SerializeField]
    private GameObject m_WinUI;

    [SerializeField]
    private PlayerController m_Player;

    public bool _isOver = false;

    void Awake(){
        m_Player = FindObjectOfType<PlayerController>();
    }
    public void FinishGame()
    {
        if (_isOver)
            return;

        _isOver = true;

        m_WinUI.SetActive(true);
        m_WinUI.transform.position = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, m_GameOverUI.transform.position.z);
        m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.End;
        m_Player.Stop();
        m_Player._rigBod.gravityScale = 0;
        m_Player._rigBod.velocity = Vector3.zero;
        m_Player._rigBod.freezeRotation = true;
    }

    public void GameOver()
    {
        if (_isOver)
            return;

        _isOver = true;

        m_GameOverUI.SetActive(true);
        m_GameOverUI.transform.position = new Vector3(m_Player.transform.position.x, m_Player.transform.position.y, m_GameOverUI.transform.position.z);
        m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.Dead;
        m_Player.Stop();
        m_Player._rigBod.gravityScale = 0;
        m_Player._rigBod.velocity = Vector3.zero;
        m_Player._rigBod.freezeRotation = true;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}