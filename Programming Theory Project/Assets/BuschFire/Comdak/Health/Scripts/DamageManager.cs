using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private List<DamageZone> zones = new List<DamageZone>();

    [SerializeField]
    private SimpleAlignment alignment;

    private void Start()
    {
        zones.AddRange(GetComponentsInChildren<DamageZone>());
        for (int i = 0; i < zones.Count; i++)
        {
            zones[i].SetAlignment(alignment);
            zones[i].Damagable.m_Died.AddListener(OnComponentDeath);
            zones[i].Damagable.m_Damaged.AddListener(OnComponentDamaged);
        }
    }

    private void OnComponentDeath(Damagable damagable)
    {
        if(damagable.m_IsCriticalPart)
        {
            //Play Explosion
            Destroy(gameObject);
        }
        else
        {
            damagable.m_Died.RemoveAllListeners();
            damagable.m_Damaged.RemoveAllListeners();
            Destroy(damagable.gameObject);
        }
    }

    private void OnComponentDamaged(Damagable damagable)
    {
        //Show Damage Bar
    }
}
