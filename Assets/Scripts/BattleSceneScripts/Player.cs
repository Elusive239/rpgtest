using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player", order = 1)]
//Houses player fields and methods, primarily for scriptable object used in combat.
public class Player : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;
    public bool priority;
    public Attack[] attacks = new Attack[4];
    public ItemSO[] items = new ItemSO[1];

    public void TakeDamage(int AtkDamage){
        currentHealth = currentHealth - AtkDamage;
    }
    public void Heal(int healVal){
        currentHealth = currentHealth + healVal;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    public int RemoveItem(string itemName){
        int count = 0;
        foreach(ItemSO i in items){
            if(i.item.itemName == itemName){
                i.item.itemQuantity -= 1;
                if(i.item.itemQuantity < 1){
                    List<ItemSO> itemList = new List<ItemSO>(items);
                    itemList.RemoveAt(count);
                    items = itemList.ToArray();
                }
                return i.item.itemQuantity;
            }
            count++;
        }
        return 0;
    }
}
