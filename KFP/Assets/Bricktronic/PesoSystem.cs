using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesoSystem : MonoBehaviour
{
    public static int Pesos;

    int LastP;

    private void Update()
    {
        if (LastP != Pesos)
        {
            GetComponent<Text>().text = Pesos.ToString();
            LastP = Pesos;
        }
    }
}
