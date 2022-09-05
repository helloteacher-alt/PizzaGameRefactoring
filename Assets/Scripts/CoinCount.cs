using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    int totalCoin;
    public int plusCoin;
   
    void Start()
    {
        coinCountText.GetComponent<Text>();
        totalCoin = 0;
    }

    public void GetCoinCount()
    {
        totalCoin = totalCoin+plusCoin;
        coinCountText.text = totalCoin.ToString();
    }
}
