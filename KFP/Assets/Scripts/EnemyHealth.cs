using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Enemy health. Enemies flash when they take damage. Requires a Flasher.
/// </summary>
/// 
[RequireComponent(typeof(RedFlasher))]
public class EnemyHealth : Health
{
    RedFlasher flasher; //serialize do not force
    [SerializeField] UnityEvent reactionWhenHealthIsZero;
    [SerializeField] bool flashWhenHurt = true;

    public GameObject DeathObject;

    bool HasDied = false;

    private void Start()
    {
        flasher = GetComponent<RedFlasher>();

        int HealthAdd = LevelSystem.LevelDifficulty;
        if (HealthAdd > 4)
            HealthAdd = 4;

        currentHealth += HealthAdd;
    }

    /// <summary>
    /// Increase enemy health by a certain amount.
    /// </summary>
    /// <param name="increaseAmount"></param>
    public override void IncreaseHealth(int increaseAmount)
    {
        currentHealth += increaseAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// Decrease enemy health and flash using Flasher.
    /// </summary>
    /// <param name="decreaseAmount"></param>
    public override void DecreaseHealth (int decreaseAmount)
    {
        currentHealth -= decreaseAmount;
        flasher.FlashColor();
        TryDialog();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            TryFallApart();
            reactionWhenHealthIsZero.Invoke();
            DialogHandler.CheckDeath(this.gameObject);
            HasDied = true;
        }
    }

    public void TryFallApart()
    {
        if (HasDied)
            return;

        if(Random.Range(0,5) == 4)
        {
            if (gameObject != null)
            {
                GameObject Peso = Instantiate(Resources.Load("Peso") as GameObject);
                Peso.transform.position = this.transform.position;
            }
        }

        if (DeathObject != null)
        {
            Instantiate(DeathObject,this.transform.position,this.transform.rotation);
            //Debug.Log("Spawned Death Part");
        }
    }

    public void TryDialog()
    {
        if (GetComponent<Crackhead>() != null)
        {
            DialogHandler.PlayEnemyDialog(this.gameObject, "Dialog/Crackhead/crackhead getting hit");
        }

        if (GetComponent<CyclopsLotLizard>())
        {
            DialogHandler.PlayEnemyDialog(this.gameObject, "Dialog/Lot Lizard/Third Eye/lot lizard third eye getting hit 1");
        }

        if (GetComponent<GlassesLotLizard>() != null)
        {
            DialogHandler.PlayEnemyDialog(this.gameObject, "Dialog/Lot Lizard/Snake/lot lizard snake getting hit 1");
        }
    }
}
