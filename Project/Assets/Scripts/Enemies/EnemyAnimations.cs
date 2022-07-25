using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string attack_key;
    [SerializeField] private string die_key;

    public void SetAttack() => animator.SetTrigger(attack_key);
    public void SetDie() => animator.SetTrigger(die_key);
}