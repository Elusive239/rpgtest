using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem 
{
    public string itemName, itemDesc;
    public int itemModValue, itemQuantity;
    public ItemFlag flags;

    public bool CheckFlag(ItemFlag flag){
        return (flags & flag) == flag;
    }
}
