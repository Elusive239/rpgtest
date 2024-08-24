using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New_Entity", menuName = "ScriptableObjects/Entity", order = 1)]
public class Entity : ScriptableObject
{
    public int maxHealth;
    public int currentHealth;
    public bool priority;
    public Attack[] attacks = new Attack[0];
    public ItemSO[] items = new ItemSO[0];

    public void TakeDamage(Attack atk){
        currentHealth -= atk.attackDamage;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
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
