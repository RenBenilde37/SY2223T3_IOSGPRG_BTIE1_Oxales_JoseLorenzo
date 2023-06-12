using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health //: MonoBehaviour
{
    int maxHp;
    int hp;

    public int HealthComponent
    {
        get
        { 
            return hp; 
        }
        set
        { 
            hp = value; 
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }

    public Health(int health, int maxHealth)
    {
        hp = health;
        maxHp = maxHealth;
    }

    public void DamageHealth(int damage)
    {
        if(hp > 0)
        {
            hp -= damage;
        }
    }

    public void Heal(int healAmount)
    {
        if(hp < maxHp)
        {
            hp += healAmount;
        }
    }
}
