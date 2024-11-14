using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JetpackController : MonoBehaviour
{
    private PlayerController m_Player;
    private bool IsJetpackActive = false;
    public float JetpackForce = 20f;

    public Sprite JetpackOn;
    public Sprite JetpackOff;
    public AudioSource jetpackSound;

    void Awake(){
        m_Player = FindObjectOfType<PlayerController>();
        IsJetpackActive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Player._isJetpackEquipped){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsJetpackActive = true;
                jetpackSound.Play();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsJetpackActive = false;
                jetpackSound.Stop();
            }
        }else{
            IsJetpackActive = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (IsJetpackActive && m_Player._isJetpackEquipped)
        {
            this.GetComponent<SpriteRenderer>().sprite = JetpackOn;
            m_Player._rigBod.AddForce(Vector2.up * JetpackForce);
        }else{
            this.GetComponent<SpriteRenderer>().sprite = JetpackOff;
        }
    }
}
