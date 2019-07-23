using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShopDonut1 : MonoBehaviour
{   
    //Holds the price for the powerup, how many pesos the Player will lose on purchase.
    public int donutPrice;

    private void  OnMouseDown()
    {
        PurchaseDonut(donutPrice);

    }

    protected void PurchaseDonut(int donutPrice)
    {

        //These are placeholders as Powerup Donuts and Pesos haven't been implemented yet.
        //Player.Pesos - donutPrice
        //Give Player the selected powerup/donut
        Debug.Log("Donut Purchased For" + " " + donutPrice);

    }

    void Update()
    {
        
        
    }
}
