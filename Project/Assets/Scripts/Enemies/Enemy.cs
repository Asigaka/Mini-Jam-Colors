using DG.Tweening;
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

    [HideInInspector] public UnityEvent onDie;

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

    private void CheckObstacleForward()
    {

    }

    public void AttackPlayer(Player player)
    {
        player.Damage(damage);
    }

    public void Kill()
    {
        onDie.Invoke();
        Destroy(gameObject);
    }
}
