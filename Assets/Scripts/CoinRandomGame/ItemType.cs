using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemType : MonoBehaviour
{
    public enum ItemsType{
        Coin100,
        Coin50,
        Coin10,
        Coin5
        
    }
    
    public ItemsType type;
    public Sprite image;
    public static string[] names = {"Coin100" , "Coin50" , "Coin10" , "Coin5"};

    public string GetName()
    {
        return names[(int)(type)];
    }

}

