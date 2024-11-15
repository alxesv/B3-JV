using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenSaltItem : MonoBehaviour
{
    public AudioSource saltAudioSource;
    public static int goldenSaltPoint = 200;
    public static bool isBonusGoldenSalt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            saltAudioSource.Play();
            isBonusGoldenSalt = true;
            GameManager.score += goldenSaltPoint;
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(gameObject, saltAudioSource.clip.length);
        }
    }
}
