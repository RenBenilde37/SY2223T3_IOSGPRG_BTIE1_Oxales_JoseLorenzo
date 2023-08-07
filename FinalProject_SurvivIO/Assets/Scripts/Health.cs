using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    int health;
    int maxHealth;

    int currentHealth;

    public Health(int health)
    {
        this.maxHealth = health;
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetHealthMax()
    {
        return maxHealth;
    }

    public void AddHealth(int value)
    {
        this.health += value;

        if (health > maxHealth)
            health = maxHealth;
    }

    public void TakeDamage(int value)
    {
        this.health -= value;

        if (health <= 0)
            health = 0;
    }
}
    
