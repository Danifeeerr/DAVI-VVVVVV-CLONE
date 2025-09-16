using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float maxhealth;

    [SerializeField]
    private float health;

    public UnityEvent<float> OnChangeHealth;
    public UnityEvent<float> UpdateHearts;

    public UnityEvent OnHurt;

    public UnityEvent OnZeroLifes;

    public bool canGetHurt = true;

    private void Start()
    {
        health = maxhealth;

            if (this.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))        
            {
                spriteRenderer.enabled = true; // activar el render
            }   //JUST FOR TRYING THAT HEALTH SYSTEM WORKS
    }
    
    public float GetMaxHealth()
    {
        return maxhealth;
    }

    public float GetCurrenthealth()
    {
        return health;
    }

    public void SetMaxHealth(float maxh)
    {
        maxhealth = maxh;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public void Hurt(float damage)
    {
        if (!canGetHurt) return;
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player Dead");
            if (this.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))        
            {
                spriteRenderer.enabled = false; // activar el render
            }   //JUST FOR TRYING THAT HEALTH SYSTEM WORKS
        }
        OnHurt.Invoke();
    }

    public void Heal(float heal)
    {
        if (health + heal > maxhealth)
        {
            health = maxhealth;
        }
        else 
        { 
            health += heal;
        }

    }
}