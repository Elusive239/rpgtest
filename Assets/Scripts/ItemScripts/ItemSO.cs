using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New_Item", menuName = "ScriptableObjects/Item", order = 1)]

public class ItemSO : ScriptableObject
{
    public BaseItem item;
    public string GetName(){ return this.item.itemName; }
}
