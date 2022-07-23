using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    [HideInInspector] public UnityEvent onDamage;
    [HideInInspector] public UnityEvent onDie;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        onDamage.Invoke();

        if (currentHealth <= 0)
        {
            onDie.Invoke();
        }
    }
}
