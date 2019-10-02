using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static string[] Enemies = new string[] {
        "Prefabs/LevelObjects/Enemies/Crackhead",
        "Prefabs/LevelObjects/Enemies/CyclopsLotLizard",
        "Prefabs/LevelObjects/Enemies/CyclopsLotLizardKicker",
        "Prefabs/LevelObjects/Enemies/Glasses Lot Lizard"};

    public static void SpawnEnemies(int Level, Vector3 StartPosition)
    {
        for(int i = 0; i < Level*5; i++)
        {
            GameObject Enemy = Instantiate(Resources.Load(Enemies[Random.Range(0,4)]) as GameObject);
            Enemy.transform.position = StartPosition + new Vector3((i * 5f + Random.Range(0.0f,3.5f)) + Random.Range(20,30), 0, 0) * Level;

            GameObject Peso = Instantiate(Resources.Load("Prefabs/Peso") as GameObject);
            Enemy.transform.position = StartPosition + new Vector3((i * Random.Range(5,8.1f) + Random.Range(0.0f, 7.5f)) + Random.Range(20, 30), 0, 0) * Level;


        }
    }
}
