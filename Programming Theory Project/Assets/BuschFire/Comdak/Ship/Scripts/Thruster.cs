using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    
    public float thrustForce = 1;
       
    public void Activate(ref Rigidbody rb)
    {
        rb.AddForceAtPosition(-transform.forward*thrustForce, transform.position,ForceMode.Force);
    }
}
