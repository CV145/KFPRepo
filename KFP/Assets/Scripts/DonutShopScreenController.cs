using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShopScreenController : MonoBehaviour
{
    //Controls all the fancy things the happen during the Donut Shop Screen.
    
    public GameObject donutShopExterior;
    public GameObject donutShopInterior;
    public Animator anim;
    void Start()
    {

        donutShopExterior.SetActive(true);
        donutShopInterior.SetActive(false);
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown ()
    {
        //Fades in the screen before changing the backdrop to the interior of the Donut Shop
        anim.SetTrigger("FadeOut");
        donutShopExterior.SetActive(false);
        donutShopInterior.SetActive(true);
        anim.SetTrigger("FadeIn");

    }
}
