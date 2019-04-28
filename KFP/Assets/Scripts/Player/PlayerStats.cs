using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in charge of storing player data, simplifies number of references the UI will need by having everything in one place
public class PlayerStats : MonoBehaviour
{
    public int ammoCount;
    public int health;
    public int score;
    private int enemiesKilled;
    private int shotsFired;
    private float accuracyValue;
}
