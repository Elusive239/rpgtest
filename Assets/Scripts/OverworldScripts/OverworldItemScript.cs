using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverworldItemScript : MonoBehaviour
{
    public Player player;
    public GameObject option;
    public Button optionButton;
    public TMP_Text optionName;
    public TMP_Text optionVal;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        //Find this option and set our text values accordingly
        foreach(Item i in player.items){
            if(i.name == option.name){
                item = i;
                optionName.text = item.name;
                optionVal.text = item.desc + "";
                if(item.dmgVal > 0){
                    optionButton.interactable = false;
                }
            }
        }
    }
    //enemy takes damage based on the selection, then player passes priority
    public void onOptionSelect(){
        if(player.HP < player.MaxHP){
            if(item.healVal > 0){
                player.heal(item.healVal);
            }
            if(item.consumable){
                int count = 0;
                foreach(Item i in player.items){
                    if(i.name == item.name){
                        i.quantity -= 1;
                    }
                    if(i.quantity < 1){
                        List<Item> itemList = new List<Item>(player.items);
                        itemList.RemoveAt(count);
                        player.items = itemList.ToArray();
                        Destroy(option);
                    }
                    count++;
                }
            }
        }
    }
}
