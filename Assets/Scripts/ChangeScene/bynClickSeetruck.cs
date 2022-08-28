using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bynClickSeetruck : MonoBehaviour
{
    public void ClickToChangeScene()
    {
        SceneManager.LoadScene("SeeTruck");
    }
}
