using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnClickIntro : MonoBehaviour
{
    public void ClickToNewScene()
    {
        SceneManager.LoadScene("IntroStory02");
    }
}
