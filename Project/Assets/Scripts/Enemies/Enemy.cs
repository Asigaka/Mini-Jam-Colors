using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage = 2;

    [Space]
    [SerializeField] private EnemyMovement movement;
    [SerializeField] private EnemyAnimations animations;
    [SerializeField] private EnemyCombat combat;
    [SerializeField] private EnemyColors colors;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collr2D;

    [HideInInspector] public UnityEvent onKill;
    [HideInInspector] public Action<Enemy> onDie;

    public Color GetColor { get => colors.SpriteRenderer.color; }

    private Vector2 target;

    private void Start()
    {
        colors.SetRandomColor();
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

    public void AttackPlayer(Player player)
    {
        animations.SetAttack();
        player.Damage(damage);
    }

    public void Kill()
    {
        rb.bodyType = RigidbodyType2D.Static;
        collr2D.isTrigger = true;
        animations.SetDie();
        Destroy(gameObject, 0.9f);
        onDie.Invoke(this);
        onKill.Invoke();
    }
}
