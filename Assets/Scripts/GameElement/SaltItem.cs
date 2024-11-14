using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltItem : MonoBehaviour
{
    public AudioSource saltAudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        saltAudioSource.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.score += 50;
            Destroy(gameObject);
        }
    }
}