using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Range(1f, 12f)]
    public float maximumRotationRate;
    private float rotationRate;
    private Vector3 rotationAxis;
    // Start is called before the first frame update
    void Start()
    {
        rotationRate = Random.Range(0.1f, maximumRotationRate);
        rotationAxis = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, rotationAxis, rotationRate);
    }
}
