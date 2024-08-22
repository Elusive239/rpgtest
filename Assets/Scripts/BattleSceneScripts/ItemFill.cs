using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFill : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public GameObject option;
    public TMP_Text optionName;
    public TMP_Text optionVal;
    ItemSO selectedItem ;
    // Start is called before the first frame update
    void Start()
    {
        //Find this option and set our text values accordingly
        foreach(ItemSO i in player.items){
            if(i.item.itemName == option.name){
                selectedItem = i;
                optionName.text = i.item.itemName;
                optionVal.text = i.item.itemDesc + "";
            }
        }
    }
    //enemy takes damage based on the selection, then player passes priority


    public void OnOptionSelect(){
        
        if(!selectedItem.item.CheckFlag(ItemFlag.CONSUMABLE)){
            Debug.Log($"Item {selectedItem} is not consumable");
            return;
        }

        if(selectedItem.item.CheckFlag(ItemFlag.DAMAGING)){
            if(selectedItem.item.CheckFlag(ItemFlag.THROWABLE))
                enemy.TakeDamage(selectedItem.item.itemModValue);
            else {
                player.TakeDamage(selectedItem.item.itemModValue);
            }
        }

        if(selectedItem.item.CheckFlag(ItemFlag.HEALING)){
            if(selectedItem.item.CheckFlag(ItemFlag.THROWABLE))
                enemy.Heal(selectedItem.item.itemModValue);
            else {
                player.Heal(selectedItem.item.itemModValue);
            }
        }

        if(!selectedItem.item.CheckFlag(ItemFlag.KEY)){
            if(!selectedItem.item.CheckFlag(ItemFlag.KEY)){
                int itemQuantity = player.RemoveItem(selectedItem.item.itemName);
                if(itemQuantity == 0) Destroy(option);
            }
        }
        player.priority = false;
    }
}
