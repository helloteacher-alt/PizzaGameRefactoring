using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnClickOpenMail : MonoBehaviour
{
    public void ClickToNewScene()
    {
        SceneManager.LoadScene("openMail");
    }
}
