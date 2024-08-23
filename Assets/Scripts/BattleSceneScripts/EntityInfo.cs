using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityInfo : MonoBehaviour
{
    private Entity entity;
    private Slider slider;

    public void Awake(){
        this.slider = GetComponentInChildren<Slider>();
    }

    public void SetEntity(Entity entity){
        this.entity = entity;
        slider.maxValue = entity.maxHealth;
        slider.value = entity.currentHealth;
    }

    public void UpdateSlider(){
        slider.value = entity.currentHealth;
    }
}
