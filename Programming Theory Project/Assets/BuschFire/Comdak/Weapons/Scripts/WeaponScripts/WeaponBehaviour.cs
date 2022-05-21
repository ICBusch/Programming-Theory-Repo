using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField]
    private WeaponObject m_Weapon;
    public Transform m_LaunchPostion;
    public int m_WeaponGroup = 0;
    private bool isReadyToFire;

    private void Start()
    {
        if (!isReadyToFire)
            StartCoroutine(CoolDown());

        if (m_LaunchPostion == null)
            m_LaunchPostion = transform;
    }

    public void FireWeapon()
    {
        if (isReadyToFire)
        {
            m_Weapon.Fire(m_LaunchPostion);
            isReadyToFire = false;
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()  // ABSTRACTION
    {

        yield return new WaitForSeconds(m_Weapon.CoolDownTime);
        isReadyToFire = true;

    }
}
