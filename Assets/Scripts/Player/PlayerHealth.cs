using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int _playerHealth;
    public int _maxHealth;
    public bool _isImmune = false;
    [SerializeField]
    private float invulnFrameDuration;

    [SerializeField]
    private PlayerController m_Player;


    void Awake(){
        m_Player = FindObjectOfType<PlayerController>();
    }
    void Start() {
        _playerHealth = 3;
        _maxHealth = 3;
    }

    public IEnumerator invulnFrame(){
        m_Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        _isImmune = true;
        yield return new WaitForSeconds(invulnFrameDuration);
        m_Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        _isImmune = false;
    }

    public void LoseHealth(int damage){
        if(_isImmune){
            return;
        }

        _playerHealth -= damage;

        if(_playerHealth == 2){
            m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.Two_HP;
        }

        if(_playerHealth == 1){
            m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.One_HP;
        }

        if (_playerHealth == 0){
            FindObjectOfType<GameManager>().GameOver();
        }else{
            StartCoroutine(invulnFrame());
        }
    }

    public void GainHealth(int healing){
        if(_playerHealth < _maxHealth){
            _playerHealth += healing;

            if(_playerHealth == 2){
                m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.Two_HP;
            }

            if(_playerHealth == 3){
                m_Player.GetComponent<SpriteRenderer>().sprite = m_Player.Three_HP;
            }

        }else {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}