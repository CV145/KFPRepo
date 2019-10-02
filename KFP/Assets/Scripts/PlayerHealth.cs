using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Extension of Health component. PlayerHealth plays a camera glitch when reduced.
/// </summary>
/// 
[RequireComponent(typeof(GlitchEffectMaker))]
public class PlayerHealth : Health
{
    GlitchEffectMaker glitchEffectMaker;

    public GameObject DeathObject;
    public Canvas UICanvas;

    bool IsDead;

    private void Start()
    {
        glitchEffectMaker = GetComponent<GlitchEffectMaker>();
    }

    /// <summary>
    /// Increase max health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    /// <summary>
    /// Lower health by a given amount. For players, causes a glitch effect.
    /// </summary>
    /// <param name="amount"></param>
    public override void DecreaseHealth(int amount)
    {
        if (currentHealth > 0)
        {
            glitchEffectMaker.MakeGlitch();
            currentHealth -= amount;
        }
        else
        {
            if (!IsDead)
            {
                GameObject GO = Instantiate(Resources.Load("YouSuck") as GameObject, UICanvas.transform.position, Quaternion.identity, UICanvas.transform);
                //GO.transform.SetParent(UICanvas.transform);
                IsDead = true;

                GameObject DeathBody = Instantiate(DeathObject, transform.position, Quaternion.identity);
                Camera.main.GetComponent<CameraFocuser>().enabled = false;
                gameObject.transform.position = Vector3.down * 10;
                Mover.gameIsPaused = true;
                StartCoroutine(DeathDelay());
            }
            currentHealth = 0;
        }

        switch (Random.Range(0, 2))
        {
            case 0:
                DialogHandler.PlayKFPDialog(gameObject, "Dialog/KFP/KFP Getting hit 1");
                break;

            case 1:
                DialogHandler.PlayKFPDialog(gameObject, "Dialog/KFP/KFP Getting hit 2");
                break;
        }
    }

    public IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LevelSelector");
        Mover.gameIsPaused = false;
    }

    /// <summary>
    /// Increase health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public override void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
}
