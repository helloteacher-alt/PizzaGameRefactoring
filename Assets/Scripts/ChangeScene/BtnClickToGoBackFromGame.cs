using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnClickToGoBackFromGame : MonoBehaviour
{
    public Button ClickToGoBack;

    void Start()
    {
        Button btn = ClickToGoBack.GetComponent<Button>();
        btn.onClick.AddListener(ClickButtonToGoBack);
    }


    public void ClickButtonToGoBack()
    {
        SceneManager.LoadScene("inGame");
    }
}
