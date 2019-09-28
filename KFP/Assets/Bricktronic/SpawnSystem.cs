using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static string[] Enemies = new string[] {
        "Prefabs/LevelObjects/Enemies/Crackhead",
        "Prefabs/LevelObjects/Enemies/CyclopsLotLizard",
        "Prefabs/LevelObjects/Enemies/GlassesLotLizard"};

    public static void SpawnEnemies(int Level, Vector3 StartPosition)
    {
        for(int i = 0; i < Level*5; i++)
        {
            GameObject Enemy = Instantiate(Resources.Load(Enemies[0]) as GameObject);
            Enemy.transform.position = StartPosition + new Vector3(i * 4f + Random.Range(0.0f,0.02f) + 10, Random.Range(0,1.2f), 0) * Level;
        }
    }
}
