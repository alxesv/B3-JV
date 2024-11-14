using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaltItem : MonoBehaviour
{
    public AudioSource saltAudioSource;
    public static int saltPoint = 50;
    public static bool isBonusSalt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            saltAudioSource.Play();
            isBonusSalt = true;
            GameManager.score += saltPoint;
            Destroy(gameObject, saltAudioSource.clip.length);
        }
    }
}
