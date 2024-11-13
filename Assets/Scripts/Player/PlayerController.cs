using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rigBod;

    [SerializeField]
    private LayerMask m_GroundLayer;
    [SerializeField]
    private LayerMask m_EnemyLayer;

    [SerializeField]
    private float m_MoveSpeed;

    [SerializeField]
    private GameObject[] itemToDisappear;

    private float _movement;
    private GameManager _gameManager;

    public Sprite Three_HP;
    public Sprite Two_HP;
    public Sprite One_HP;
    public Sprite Dead;
    public Sprite End;
    public bool _isJetpackEquipped = false;
    public GameObject Jetpack;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager._isOver)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) )
        {
            foreach (GameObject item in itemToDisappear)
            {
                GameObject.Destroy(item);
            }
        }
        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        
        _rigBod.velocity = new Vector2(m_MoveSpeed * _movement, _rigBod.velocity.y);
        _rigBod.AddTorque(-_movement * 0.6f);

        if (_movement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Stop()
    {
        Jetpack.SetActive(false);
        _rigBod.velocity = new Vector2(0, _rigBod.velocity.y);
        _rigBod.gravityScale = 0;
        _rigBod.velocity = Vector3.zero;
        _rigBod.freezeRotation = true;
        enabled = false;
    }

    public void GetJetpack()
    {
        _isJetpackEquipped = true;
        Jetpack.SetActive(true);
        StartCoroutine(JetpackTimer());
    }

    public IEnumerator JetpackTimer()
    {
        yield return new WaitForSeconds(5);
        _isJetpackEquipped = false;
        Jetpack.SetActive(false);
    }
}