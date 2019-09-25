using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //[SerializeField] Text ammoCountText;
    //[SerializeField] Text scoreCountText;
    //[SerializeField] Text healthText;
    [SerializeField] Button pauseButton;

    public GameObject ActivePanel;
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    PlayerStats stats;

    void Start()
    {
      

        stats = FindObjectOfType<PlayerStats>(); 
        //ammoCountText.text = "Ammo : 12/12";
        //scoreCountText.text = "Score : 0";
        //healthText.text = "Health : 100/100";
    }

    void Update()
    {
        //Display the current ammo count every frame.
        //ammoCountText.text = "Ammo :" + " " + stats.ammoCount + "/12";
        //scoreCountText.text = "Score:" + " " + stats.score;
        //healthText.text = "Health:" + " " + stats.health + "/5";
    }

    public void setPanelOnOff(GameObject panel, bool on)
    {
        panel.SetActive(on);
    }

    public void setAllUiOff()
    {
        setPanelOnOff(ActivePanel, false);
        setPanelOnOff(StartPanel, false);
        //setPanelOnOff(GameOverPanel, false);
        setPanelOnOff(PausePanel, false);
        
    }
}
