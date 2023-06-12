using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        var enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        var maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            var targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        var targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        Attack(targetDistance < range);
    }

    void Attack(bool isActive)
    {
        var emission = projectileParticles.emission;
        emission.enabled = isActive;
    }
}
