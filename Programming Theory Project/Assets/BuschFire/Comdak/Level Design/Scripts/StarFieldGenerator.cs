using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars;
    public float range = 400;
   

    private void Start()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            SpawnRandomStar();
        }
    }

    private void SpawnRandomStar()
    {
        
        var rndPos = Random.insideUnitSphere * range;
        if (rndPos.y > 0)
            rndPos.y *= -1f;
        Instantiate(starPrefab, rndPos, Quaternion.Euler(90, Random.Range(-180, 180), 0), transform);
    }
}
