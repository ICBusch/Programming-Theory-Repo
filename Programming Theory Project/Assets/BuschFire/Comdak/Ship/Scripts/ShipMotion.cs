using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMotion : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardThrustForce;
    public List<Thruster> forwardThrusters;
    public float retroThustForce;
    public List<Thruster> retroThrusters;
    public float manuveringThrusterForce;
    public List<Thruster> CWThrusters;
    public List<Thruster> CCWThrusters;
    public List<Thruster> StrafeLeftThrusters;
    public List<Thruster> StrafeRightThrusters;

    // Start is called before the first frame update
    #region Unity Functions
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        

        for (int i = 0; i < retroThrusters.Count; i++)
        {
            retroThrusters[i].thrustForce = retroThustForce;
        }

        for (int i = 0; i < StrafeLeftThrusters.Count; i++)
        {
            StrafeLeftThrusters[i].thrustForce = manuveringThrusterForce;
        }
        for (int i = 0; i < StrafeRightThrusters.Count; i++)
        {
            StrafeRightThrusters[i].thrustForce = manuveringThrusterForce;
        }

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
    #endregion

    #region Motion Functions
    public void Thrust(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if (thrustValue > 0)
        {
            for (int i = 0; i < forwardThrusters.Count; i++)
            {
                forwardThrusters[i].Activate(ref rb);
                Debug.Log(forwardThrusters[i].transform.forward);
            }
        }
        else if (thrustValue < 0)
        {
            for (int i = 0; i < retroThrusters.Count; i++)
            {
                retroThrusters[i].Activate(ref rb);
                Debug.Log(retroThrusters[i].transform.forward);
            }
        }

    }

    public void Rotate(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if (thrustValue > 0)
        {
            for (int i = 0; i < CWThrusters.Count; i++)
            {
                CWThrusters[i].Activate(ref rb);
                Debug.Log(CWThrusters[i].transform.forward);
            }
        }
        else if (thrustValue < 0)
        {
            for (int i = 0; i < CCWThrusters.Count; i++)
            {
                CCWThrusters[i].Activate(ref rb);
                Debug.Log(CCWThrusters[i].transform.forward);
            }
        }
    }

    public void Strafe(float thrustValue)
    {
        if (Mathf.Approximately(thrustValue, 0))
            return;
        if (thrustValue > 0)
        {
            for (int i = 0; i < StrafeRightThrusters.Count; i++)
            {
                StrafeRightThrusters[i].Activate(ref rb);
            }
        }
        else if (thrustValue < 0)
        {
            for (int i = 0; i < StrafeLeftThrusters.Count; i++)
            {
                StrafeLeftThrusters[i].Activate(ref rb);
            }
        }
    } 
    #endregion

    public void SetForwardThrust(float value)
    {
        for (int i = 0; i < forwardThrusters.Count; i++)
        {
            forwardThrusters[i].thrustForce = value;
        }
    }
}
