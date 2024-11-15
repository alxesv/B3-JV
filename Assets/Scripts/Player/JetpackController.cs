using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JetpackController : MonoBehaviour
{
    private PlayerController m_Player;
    public float JetpackForce = 20f;

    public Sprite JetpackOn;
    public Sprite JetpackOff;
    public AudioSource jetpackSound;

    void Awake(){
        m_Player = FindObjectOfType<PlayerController>();
        m_Player._isJetpackActive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Player._isJetpackActive = true;
                jetpackSound.Play();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                m_Player._isJetpackActive = false;
                jetpackSound.Stop();
            }
    }

    private void FixedUpdate()
    {
        if (m_Player._isJetpackActive)
        {
            this.GetComponent<SpriteRenderer>().sprite = JetpackOn;
            m_Player._rigBod.AddForce(Vector2.up * JetpackForce);
        }else{
            this.GetComponent<SpriteRenderer>().sprite = JetpackOff;
        }
    }
}
