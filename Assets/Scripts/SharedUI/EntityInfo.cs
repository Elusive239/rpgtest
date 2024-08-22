using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EntityInfo : MonoBehaviour
{
    public int health = 100;
    public Slider slider;

    public void TakeDamage(int AtkDamage){
        health -= AtkDamage;
        slider.value = health;
    }
}
