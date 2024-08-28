using System;
using UnityEngine;

[System.Flags]
public enum ItemFlag{
    CONSUMABLE = 1, 
    DAMAGING = ItemFlag.CONSUMABLE*2, 
    HEALING = ItemFlag.DAMAGING*2,  
    KEY = ItemFlag.HEALING*2, 
    THROWABLE = ItemFlag.KEY*2, 
}