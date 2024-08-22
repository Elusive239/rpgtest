using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveFill : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public GameObject option;
    public TMP_Text optionName;
    public TMP_Text optionVal;
    Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        //Find this option and set our text values accordingly
        foreach(Attack i in player.attacks){
            if(i.name == option.name){
                attack = i;
                optionName.text = attack.name;
                optionVal.text = attack.damage + "";
            }
        }
    }
    //enemy takes damage based on the selection, then player passes priority
    public void OnOptionSelect(){
        enemy.TakeDamage(attack.damage);
        player.priority = false;
    }
}
