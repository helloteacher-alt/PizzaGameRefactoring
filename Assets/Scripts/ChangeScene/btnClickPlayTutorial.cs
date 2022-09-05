using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnClickPlayTutorial : MonoBehaviour
{
    public void ClickPlayToLoadScene()
    {
        SceneManager.LoadScene("inGame");
    }
    public void ClickTutorialToLoadScene()
    {
        SceneManager.LoadScene("inTutorial");
    }
}
