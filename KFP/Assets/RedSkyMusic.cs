using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSkyMusic : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource source2;
    void Start()
    {
        source.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        source2.Stop();
        source.Play();

    }
}
