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
    public bool _canMove = true;
    public Sprite Three_HP;
    public Sprite Two_HP;
    public Sprite One_HP;
    public Sprite Dead;
    public Sprite End;
    public bool _isJetpackActive = false;
    public GameObject Jetpack;
    public GameObject Parachute;

    public bool _isParachuteEquipped = false;

    private float linearDrag;

    private Coroutine JetPackCoroutine;
    private Coroutine ParachuteCoroutine;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rigBod = GetComponent<Rigidbody2D>();
        linearDrag = _rigBod.drag;
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
            if(_gameManager.isCountOn == false){
                _gameManager.isCountOn = true;
            }
            if(_gameManager.isMusicOn == false){
                _gameManager.music.Play();
                _gameManager.isMusicOn = true;
            }
            foreach (GameObject item in itemToDisappear)
            {
                GameObject.Destroy(item);
            }
        }
        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(_isParachuteEquipped){
            _rigBod.drag = 3.5f;
        }else{
            _rigBod.drag = linearDrag;
        }

        if(_canMove){

            if (Mathf.Abs(_movement) > 0.01f)
            {
                _rigBod.velocity = new Vector2(m_MoveSpeed * _movement, _rigBod.velocity.y);
            }
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
    }

    public void Stop()
    {
        Jetpack.SetActive(false);
        _rigBod.velocity = new Vector2(0, _rigBod.velocity.y);
        _rigBod.gravityScale = 0;
        _rigBod.velocity = Vector3.zero;
        _rigBod.freezeRotation = true;
        removeAllItems();
        enabled = false;
    }

    public void removeAllItems(){
        // remove all items
        _isJetpackActive = false;
        Jetpack.SetActive(false);

        _isParachuteEquipped = false;
        Parachute.SetActive(false);
    }

    public void GetJetpack()
    {
        _isJetpackActive = false;
        Jetpack.SetActive(true);
        if(JetPackCoroutine != null){
            StopCoroutine(JetPackCoroutine);
        }
        JetPackCoroutine = StartCoroutine(JetpackTimer());
    }

    public IEnumerator JetpackTimer()
    {
        yield return new WaitForSeconds(5);
        _isJetpackActive = false;
        Jetpack.SetActive(false);
    }

    public void GetParachute()
    {
        _isParachuteEquipped = true;
        Parachute.SetActive(true);
        if(ParachuteCoroutine != null){
            StopCoroutine(ParachuteCoroutine);
        }
        ParachuteCoroutine = StartCoroutine(ParachuteTimer());
    }

    public IEnumerator ParachuteTimer()
    {
        yield return new WaitForSeconds(5);
        _isParachuteEquipped = false;
        Parachute.SetActive(false);
    }
}