using System;
using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] private float m_moveSpeed = 0.5f;

    protected override void Update()
    {
        base.Update();
        if(!IsWithinAttackRange)
        MoveTowardsPlayer();
    }

    protected override void Attack()
    {
        base.Attack();
        // new information about slimes specific attack
    }

    private void MoveTowardsPlayer()
    {
        if (m_playerTarget == null) return;

        transform.position = Vector3.MoveTowards(transform.position, m_playerTarget.position, m_moveSpeed * Time.deltaTime);
    }
}
