using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveFill : MonoBehaviour
{
    public Entity player;
    public Entity enemy;
    public GameObject option;
    public TMP_Text optionName;
    public TMP_Text optionVal;
    Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        //Find this option and set our text values accordingly
        foreach(Attack i in player.attacks){
            if(i.attackName == option.name){
                attack = i;
                optionName.text = attack.attackName;
                optionVal.text = attack.attackDamage + "";
            }
        }
    }
    //enemy takes damage based on the selection, then player passes priority
    public void OnOptionSelect(){
        enemy.TakeDamage(attack.attackDamage);
        player.priority = false;
    }
}
