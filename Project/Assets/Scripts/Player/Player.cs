using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float attackRange = 2;
    [SerializeField] private LayerMask attackLayers;
    [SerializeField] private Transform attackPoint;

    [Space]
    [SerializeField] private Health health;
    [SerializeField] private PlayerCombat combat;
    [SerializeField] private PlayerAnimations animations;

    [Space]
    [SerializeField] private AudioClip loseHealth;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip hitMiss;

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
            SoundsController.Instance.PlayOneShotSound(hit);
            animations.SetSucsess();
            onEnemyKill.Invoke();
        }
        else
        {
            SoundsController.Instance.PlayOneShotSound(hitMiss);
            animations.SetWrong();
            onEnemyMiss.Invoke();
        }
    }

    private Enemy GetNearEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, attackPoint.right, attackRange, attackLayers);

        if (hit.collider)
        {
            return hit.collider.GetComponentInParent<Enemy>();
        }

        return null;
    }

    public void Damage(float damage)
    {
        SoundsController.Instance.PlayOneShotSound(loseHealth);
        health.Damage(damage);
    }

    private void Die()
    {
        SceneManager.LoadScene(1);
        //Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(attackPoint.position, attackPoint.right * attackRange);
    }
}
