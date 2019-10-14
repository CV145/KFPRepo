using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static GameObject HealthUI;

    public static PlayerHealth PHealth;

    public bool PlayerDetected;

    int CurrentBar = 0;

    Sprite HSprite;

    private void Update()
    {
        if (!PlayerDetected)
        {
            if(Player.PlayerObject!=null && Player.PlayerObject.GetComponent<PlayerHealth>() != null)
            {
                PHealth = Player.PlayerObject.GetComponent<PlayerHealth>();

                HealthUI = Instantiate(Resources.Load("HealthPanel") as GameObject, PHealth.UICanvas.transform);
                PlayerDetected = true;
            }
        }

        if (PHealth.CurrentHealth >= 2 && CurrentBar!=1)
        {
            HealthUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("KFP_HealthBar/yellow");
            CurrentBar = 1;
        } else if (PHealth.CurrentHealth == 1 && CurrentBar!=2)
        {
            HealthUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("KFP_HealthBar/red");
            CurrentBar = 2;
        } else if (PHealth.CurrentHealth <= 0 && CurrentBar != 3)
        {
            HealthUI.GetComponent<Image>().sprite = Resources.Load<Sprite>("KFP_HealthBar/empty");
            CurrentBar = 3;
        }
    }
}
