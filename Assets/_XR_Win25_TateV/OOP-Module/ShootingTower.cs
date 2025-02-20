using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ShootingTower : Enemy
{

    [SerializeField] private Transform m_torret;
    [SerializeField] private Projectile m_projectilePrefab;

    private IObjectPool<Projectile> projectilePool;

    protected override void Awake()
    {
        base.Awake();
        projectilePool = new ObjectPool<Projectile>(CreateBullet, OnGet, OnRelease, OnBulletDestroy);
    }

    private Projectile CreateBullet()
    {
        Projectile projectile = Instantiate(m_projectilePrefab, m_torret.position, m_torret.rotation);
        // set pool on projectile
        projectile.SetPool(projectilePool);
        return projectile;
    }

    private void OnGet(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.transform.SetPositionAndRotation(m_torret.position, m_torret.rotation);
    }

    private void OnRelease(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnBulletDestroy(Projectile projectile)
    {
        Destroy(projectile.gameObject);
    }

    protected override void Attack()
    {
        base.Attack();
        AimTorret(m_playerTarget);
        Fire();
    }

    private void AimTorret(Transform target)
    {
        // Get the direction from the object to the player
        Vector3 direction = m_playerTarget.position - transform.position;

        // Zero out the Y component to prevent rotation on the vertical axis
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            // Create a rotation towards the target while ignoring vertical rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    private void Fire()
    {
        //convert this to object pool for more efficiency. Retrieve object from pool.
        //Projectile projectile = Instantiate(m_projectilePrefab, m_torret.position, m_torret.rotation);
        Projectile projectile = projectilePool.Get();
        projectile.Shoot(m_attackDamage);
    }

}
