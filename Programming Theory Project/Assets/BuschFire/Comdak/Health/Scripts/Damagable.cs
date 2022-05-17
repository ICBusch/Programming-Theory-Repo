using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider), typeof(DamageZone))]
public class Damagable : MonoBehaviour
{
    public float m_MaxHealth;
    public float m_CurrentHealth { get; private set; }

    public bool m_IsCriticalPart = false;

    public UnityEvent<Damagable> m_Died;
    public UnityEvent<Damagable> m_Damaged;
    public UnityEvent m_HealthReset;

    //private void Awake()
    //{
    //    //m_Died = new UnityEvent<Damagable>();
    //    //m_Damaged = new UnityEvent<Damagable>();
    //    //m_HealthReset = new UnityEvent();
    //}

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }
    public void SustainDamage(float amount)
    {
        m_CurrentHealth -= amount;
        m_Damaged?.Invoke(this);

        if(m_CurrentHealth < 0)
        {
            m_Died?.Invoke(this);
        }
    }

    private void ResetHealth()
    {
        SetHealth(m_MaxHealth);
        m_HealthReset?.Invoke();
    }

    private void ChangeHealth(float amount)
    {
        m_CurrentHealth += amount;
    }

    private void SetHealth(float amount)
    {
        m_CurrentHealth = amount;
    }
}
