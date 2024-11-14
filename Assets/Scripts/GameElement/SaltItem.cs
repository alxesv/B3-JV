using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.score += 5;
            Destroy(gameObject);
        }
    }
}