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



    public UnityEvent OnZeroLifes;

    private void Start()
    {
        health = maxhealth;
        this.gameObject.SetActive(true); //JUST FOR TRYING THAT HEALTH SYSTEM WORKS
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
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player Dead");
            this.gameObject.SetActive(false); //JUST FOR TRYING THAT HEALTH SYSTEM WORKS
        }
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