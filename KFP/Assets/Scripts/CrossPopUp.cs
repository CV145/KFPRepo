using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPopUp : MonoBehaviour
{
    public GameObject popup;

    private void OnMouseDown()
    {
        if (!popup.activeSelf)
        {
            popup.SetActive(true);
        } else
        {
            popup.SetActive(false);
        }
    }
}
