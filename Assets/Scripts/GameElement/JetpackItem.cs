using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().GetJetpack();
            Destroy(gameObject);
        }
    }
}
