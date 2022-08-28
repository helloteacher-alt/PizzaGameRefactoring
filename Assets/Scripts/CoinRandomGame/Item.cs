using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public enum ItemType{
        Coin100,
        Coin50,
        Coin10,
        Coin5
        
    }
    
    public ItemType type;
    public Sprite image;
    public static string[] names = {"Coin100" , "Coin50" , "Coin10" , "Coin5"};

    public string GetName()
    {
        return names[(int)(type)];
    }

}
