using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    //public WeaponObject weapon;
    //public Transform launchPosition;

    public WeaponBehaviour weaponSystem;

    
    public void FireWeapon()
    {
        weaponSystem.FireWeapon();
       
    }
           

}
