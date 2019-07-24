using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShopSounds : MonoBehaviour
{

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        source.GetComponent<AudioSource>();
        source.Play();
    }
}
