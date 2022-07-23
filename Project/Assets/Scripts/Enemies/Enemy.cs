using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float checkRange = 2;
    [SerializeField] private LayerMask checkLayer;

    [Space]
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyAnimations animations;
    [SerializeField] private EnemyCombat combat;

    private Vector2 target;
    private bool canAttackPlayer;
    private bool stop;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckObstacleForward();

        if (canAttackPlayer)
        {

        }
    }

    private void FixedUpdate()
    {
        
    }

    public void SetTarget(Vector2 target)
    {
        this.target = target;
        movement.SetMoveTarget(target);
    }

    public void JumpOn(int increaseOn)
    {
        movement.JumpOn(increaseOn);
    }

    private void CheckObstacleForward()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, checkRange, checkLayer);

        if (hit)
        {
            Player player = GetComponentInParent<Player>();
            canAttackPlayer = player != null;


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.right * checkRange);
    }
}
