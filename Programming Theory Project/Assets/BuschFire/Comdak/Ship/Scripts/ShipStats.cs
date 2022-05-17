using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Space Comdak/Ships/Ship Stats")]
public class ShipStats : ScriptableObject
{
    public float Hitpoints;
    public float ArmourRating;
    public float MainThrusterForce;
    public float RetroThrusterForce;
    public float ManuveringThrusterForce;
}
