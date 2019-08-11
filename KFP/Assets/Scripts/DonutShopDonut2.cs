using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutShopDonut2 : DonutShopDonut1
{
    void Start()
    {
        
        donutPrice = 20;

    }

    private void OnMouseDown()
    {

        PurchaseDonut(donutPrice);

    }
}
