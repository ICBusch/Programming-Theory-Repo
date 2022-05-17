using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : Component
{
    public float m_Damage;
    public float m_Density;
    [SerializeField]
    private SimpleAlignment m_alignment;
    public void CauseDamage(Collider other)
    {
        DamageZone damageZone = other.GetComponent<DamageZone>();
        if(damageZone != null)
        {
            if(m_alignment.CanHarm(damageZone.Alignment))
            {
                damageZone.SustainDamage(m_Damage);
            }
        }
    }

    private void DeterminePenetrationLevel(float impactedDensity)
    {
        float absorbtion = m_Density - impactedDensity;

    }

}
