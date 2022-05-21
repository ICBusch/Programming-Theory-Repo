using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Space Comdak/Weapons/Projectile Weapon")]
public class ProjectileWeapon : WeaponObject // INHERITANCE
{
    public ProjectileBehaviour ProjectilePrefab;
    public float lifeTime;  
    public float velocity;


    public override void Fire(Transform launchPosition)  // POLYMORPHISM
    {
        var projectile = Instantiate<ProjectileBehaviour>(ProjectilePrefab, launchPosition.position, launchPosition.rotation);
        projectile.Damage = Damage;
        var rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = projectile.transform.forward * velocity;

        Destroy(projectile.gameObject, lifeTime);
    }
}
