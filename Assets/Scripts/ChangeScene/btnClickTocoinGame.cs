using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnClickTocoinGame : MonoBehaviour
{
    public Button ClickToGame;

    void Start()
    {
        Button btn = ClickToGame.GetComponent<Button>();
        btn.onClick.AddListener(ClickButtonToLoadScene);
    }

    public void ClickButtonToLoadScene()
    {
        SceneManager.LoadScene("CoinGame");
    }
}
