using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Slider slider;

    [HideInInspector] public UnityEvent onDamage;
    [HideInInspector] public UnityEvent onDie;

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
        onDamage.Invoke();
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            onDie.Invoke();
        }
    }
}
