using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private int numJumps;
    [SerializeField] private float duration;

    [SerializeField] private Vector2 target;

    private void Awake()
    {

    }

    private void Update()
    {
        
    }

    public void SetMoveTarget(Vector2 target)
    {
        rb.DOKill();
        this.target = target;
        float duration = Vector2.Distance(transform.position, target) / speed;
        rb.DOMoveX(target.x, duration).SetEase(Ease.Linear);
    }

    public void JumpOn(int increaseOn)
    {
        Vector2 nextPos = new Vector2(transform.position.x - increaseOn, transform.position.y);
        rb.DOJump(nextPos, jumpPower, numJumps, duration).SetEase(Ease.Linear);
    }
}
