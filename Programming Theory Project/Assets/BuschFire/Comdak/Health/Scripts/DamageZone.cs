using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Damagable))]
public class DamageZone : MonoBehaviour
{
    public Damagable Damagable { get; private set; }

    public SimpleAlignment Alignment { get; private set; }    

    public float m_DamageScale = 1.0f;
    public float m_Density = 1;

    private void Awake()
    {
        Damagable = GetComponent<Damagable>();
    }

    public void SustainDamage(float amount)
    {
        float scaledDamage = ScaleDamage(amount);

        Damagable.SustainDamage(scaledDamage);
    }

    private float ScaleDamage(float amount)
    {
        return amount * m_DamageScale;
    }

    public void SetAlignment(SimpleAlignment alignment)
    {
        Alignment = alignment;
    }

}
