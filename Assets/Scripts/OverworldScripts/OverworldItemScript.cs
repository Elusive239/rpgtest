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
    ItemSO currentItem;
    // Start is called before the first frame update
    void Start()
    {
        //Find this option and set our text values accordingly
        foreach(ItemSO i in player.items){
            if(i.item.itemName == option.name){
                currentItem = i;
                optionName.text = currentItem.item.itemName;
                optionVal.text = currentItem.item.itemDesc + "";
                if(!currentItem.item.CheckFlag(ItemFlag.CONSUMABLE)){
                    optionButton.interactable = false;
                }
            }
        }
    }
    //enemy takes damage based on the selection, then player passes priority
    public void onOptionSelect(){
        if(!currentItem.item.CheckFlag(ItemFlag.CONSUMABLE)){
            return;
        }

        if(currentItem.item.CheckFlag(ItemFlag.HEALING) && player.maxHealth < player.currentHealth){
            player.Heal(currentItem.item.itemModValue);
            int count = 0;
            foreach(ItemSO i in player.items){
                if(i.item.itemName == currentItem.item.itemName){
                    i.item.itemQuantity -= 1;
                }
                if(i.item.itemQuantity < 1){
                    List<ItemSO> itemList = new List<ItemSO>(player.items);
                    itemList.RemoveAt(count);
                    player.items = itemList.ToArray();
                    Destroy(option);
                }
                count++;
            }
        }
    }
}
