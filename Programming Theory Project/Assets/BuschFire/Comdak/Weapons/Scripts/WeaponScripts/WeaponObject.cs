using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponObject : ScriptableObject
{
    public float Damage;
    public float CoolDownTime;


    public abstract void Fire(Transform launchPosition);
   

    

   

}
