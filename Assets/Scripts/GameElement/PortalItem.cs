using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalItem : MonoBehaviour
{
    [SerializeField]
    private Transform targetLocation;


    public AudioSource portalAudioSource;

    public void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetLocation.position;
            portalAudioSource.Play();
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(gameObject, portalAudioSource.clip.length);
        }
    }
}