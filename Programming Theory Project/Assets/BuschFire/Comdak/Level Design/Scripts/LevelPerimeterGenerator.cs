using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPerimeterGenerator : MonoBehaviour
{
    public List<Asteroid> asteroids;
    public float arenaDiameter;
    public int numberOfAsteroids;

    private void Start()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector2 circlePos = Random.insideUnitCircle;
            var pos = new Vector3(circlePos.x, 0, circlePos.y).normalized * Random.Range(arenaDiameter-20,arenaDiameter+20);
            Instantiate(asteroids[Random.Range(0, asteroids.Count)], pos, Random.rotation, transform);
        }
    }
}
