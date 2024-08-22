using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayScript : MonoBehaviour
{
    public Player player;
    public GameObject itemPanel;
    public GameObject itemOptionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PopulateItems();
    }

    public void PopulateItems(){
        foreach(ItemSO i in player.items){
            GameObject option;
            option = Instantiate(itemOptionPrefab, itemPanel.transform, true);
            option.name = i.item.itemName;
        }
    }
}
