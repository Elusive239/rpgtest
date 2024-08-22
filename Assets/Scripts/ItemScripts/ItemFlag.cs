using System;
using UnityEngine;

[System.Flags]
public enum ItemFlag{
    CONSUMABLE = 1, DAMAGING = 2, HEALING = 4, KEY = 8, THROWABLE = 16
}