using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float attackRange = 2;
    [SerializeField] private LayerMask attackLayers;

    [Space]
    [SerializeField] private Health health;
    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerAnimations animations;

    [HideInInspector] public UnityEvent onEnemyKill;
    [HideInInspector] public UnityEvent onEnemyMiss;

    private void Start()
    {
        health.onDie.AddListener(Die);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttackByColor(Color.red);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AttackByColor(Color.blue);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AttackByColor(Color.black);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackByColor(Color.green);
        }
    }

    public void AttackByColor(Color color)
    {
        if (combat.TryAttack(color, GetNearEnemy()))
        {
            onEnemyKill.Invoke();
        }
        else
        {
            onEnemyMiss.Invoke();
        }
    }

    private Enemy GetNearEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, attackRange, attackLayers);

        if (hit.collider)
        {
            return hit.collider.GetComponentInParent<Enemy>();
        }

        return null;
    }

    public void Damage(float damage)
    {
        health.Damage(damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * attackRange);
    }
}
