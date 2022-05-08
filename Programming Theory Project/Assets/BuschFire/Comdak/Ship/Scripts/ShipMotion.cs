using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    private Rigidbody rb;
    public List<Thruster> forwardThrust;
    public List<Thruster> backThrust;
    public List<Thruster> CWThrust;
    public List<Thruster> CCWThrust;
    public List<Thruster> StrafeLeft;
    public List<Thruster> StrafeRight;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            Thrust(1f);
        if (Input.GetKey(KeyCode.DownArrow))
            Thrust(-1f);

        if (Input.GetKey(KeyCode.RightArrow))
            Rotate(1f);
        if (Input.GetKey(KeyCode.LeftArrow))
            Rotate(-1f);
    }

    public void Thrust(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if(thrustValue > 0)
        {
            for (int i = 0; i < forwardThrust.Count; i++)
            {
                forwardThrust[i].Activate(ref rb);
                Debug.Log(forwardThrust[i].transform.forward);
            }
        }
        else if(thrustValue < 0)
        {
            for(int i = 0; i < backThrust.Count; i++)
            {
                backThrust[i].Activate(ref rb);
                Debug.Log(backThrust[i].transform.forward);
            }
        }

    }

    public void Rotate(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if(thrustValue > 0)
        {
            for (int i = 0; i < CWThrust.Count; i++)
            {
                CWThrust[i].Activate(ref rb);
                Debug.Log(CWThrust[i].transform.forward);
            }
        }
        else if(thrustValue < 0)
        {
            for (int i = 0; i < CCWThrust.Count; i++)
            {
                CCWThrust[i].Activate(ref rb);
                Debug.Log(CCWThrust[i].transform.forward);
            }
        }
    }

    public void Strafe(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if(thrustValue > 0)
        {
            for (int i = 0; i < StrafeRight.Count; i++)
            {
                StrafeRight[i].Activate(ref rb);
            }
        }
        else if(thrustValue < 0)
        {
            for (int i = 0; i < StrafeLeft.Count; i++)
            {
                StrafeLeft[i].Activate(ref rb);
            }
        }
    }
}
