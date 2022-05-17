using System;
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

    public bool EnableAngularCounterThrust = false;

    public bool EnableLinearCounterThrust = false;

    public float CounterThrustDelay = 2.0f;
    private float currentDelay = 0;

    // Start is called before the first frame update
    #region Unity Functions
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetForwardThrustValue(forwardThrustForce);

        SetRetroThrustValue(retroThustForce);

        SetManuveringThrustValue(manuveringThrusterForce);

    }

    private void FixedUpdate()
    {
        if (EnableAngularCounterThrust && currentDelay <= 0)
            CounterAngularVelocity();

        if (EnableLinearCounterThrust && currentDelay <= 0)
            CounterLinearVelocity();



        if (rb.velocity.sqrMagnitude < 0.1f && rb.angularVelocity.sqrMagnitude < 0.1f && currentDelay <= 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
        }

        //if(rb.angularVelocity.sqrMagnitude < 0.1f && currentDelay <= 0)
        //    rb.angularVelocity = Vector3.zero;

        if (currentDelay > 0)
            currentDelay -= Time.deltaTime;

    }



    #endregion

    #region Motion Functions
    protected void Thrust(float thrustValue)
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

    protected void Rotate(float thrustValue)
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

    protected void Strafe(float thrustValue)
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


    public void DirectionalThrustInput(Vector2 thrustVector)
    {
        if (Mathf.Approximately(thrustVector.sqrMagnitude, 0))
            return;

        if (EnableLinearCounterThrust)
            ResetCounterThrustDelay();

        Thrust(thrustVector.y);
        Strafe(thrustVector.x);
    }

    public void RotationalThrustInput(float thrustValue)
    {
        if (EnableAngularCounterThrust)
            ResetCounterThrustDelay();

        Rotate(thrustValue);
    }


    private void CounterLinearVelocity()
    {
        var dirVelocity = new Vector2(rb.velocity.x, rb.velocity.z);
        if (Mathf.Approximately(dirVelocity.sqrMagnitude, 0))
            return;

        var shipForward = new Vector2(transform.forward.x, transform.forward.z);
        var shipRight = new Vector2(transform.right.x, transform.right.z);
        var forwardComp = Vector2.Dot(dirVelocity, shipForward);
        Thrust(-Mathf.Clamp(forwardComp,-1,1));
        var leftComp = Vector2.Dot(dirVelocity, shipRight);
        Strafe(-Mathf.Clamp(leftComp,-1,1));

    }

    private void CounterAngularVelocity()
    {
        var yRotationVel = rb.angularVelocity.y;
        if (Mathf.Approximately(yRotationVel, 0))
            return;

        yRotationVel = Mathf.Clamp(yRotationVel, -1, 1);

        Rotate(-yRotationVel * 0.95f);
    }

    private void ResetCounterThrustDelay()
    {
        currentDelay = CounterThrustDelay;
    }

    #endregion

    #region Set Thrust Values
    public void SetForwardThrustValue(float value)
    {
        for (int i = 0; i < forwardThrusters.Count; i++)
        {
            forwardThrusters[i].thrustForce = value;
        }
    }

    public void SetRetroThrustValue(float value)
    {
        for (int i = 0; i < retroThrusters.Count; i++)
        {
            retroThrusters[i].thrustForce = value;
        }
    }

    public void SetManuveringThrustValue(float value)
    {
        for (int i = 0; i < StrafeLeftThrusters.Count; i++)
        {
            StrafeLeftThrusters[i].thrustForce = value;
        }
        for (int i = 0; i < StrafeRightThrusters.Count; i++)
        {
            StrafeRightThrusters[i].thrustForce = value;
        }
    }
    #endregion
}
