using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Text ammoCountText;
    PlayerStats stats;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>(); 
        ammoCountText.text = "Ammo : 12/12";
    }

    void Update()
    {
        //Display the current ammo count every frame.
        ammoCountText.text = "Ammo :" + " " + stats.ammoCount + "/12";
    }
}
