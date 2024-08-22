using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
//Script for the enemy in combat. I believe the way this will interact with the rest of the game is:
//On encounter start, instantiate an enemy, overwriting the scriptable object
// based on the ID of the encounter. Stats and abilities pulled from
//a file that houses all the enemy information.
public class Enemy : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public Enemy(int currentHealth, int dmg){
        currentHealth = currentHealth;
        attackDamage = dmg;
    }
    public void TakeDamage(int dmg){
        currentHealth = currentHealth - dmg;
    }
    public void Heal(int healVal){
        currentHealth = currentHealth + healVal;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }
}
