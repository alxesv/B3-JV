using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public float fanForce = 50f;
    private PlayerController m_Player;
    private bool isPlayerInFanZone = false;

    public enum FanDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public FanDirection fanDirection = FanDirection.Up;

    void Awake()
    {
        m_Player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInFanZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInFanZone = false;
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInFanZone && m_Player != null)
        {
            switch (fanDirection)
            {
                case FanDirection.Up:
                    m_Player._rigBod.AddForce(Vector2.up * fanForce);
                    break;
                case FanDirection.Down:
                    m_Player._rigBod.AddForce(Vector2.down * fanForce);
                    break;
                case FanDirection.Left:
                    m_Player._rigBod.AddForce(Vector2.left * fanForce);
                    break;
                case FanDirection.Right:
                    m_Player._rigBod.AddForce(Vector2.right * fanForce);
                    break;
            }
        }
    }
}