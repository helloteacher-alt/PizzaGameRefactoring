using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeShow : MonoBehaviour
{
    public Text finishText, startText;
    public Button playAgainBtn, backToMenuBtn, followBtn;
    public GameObject recipeShow;

    void Start()
    {
        finishText.enabled = false;
        startText.enabled = true;
        StartCoroutine(AlreadyStart());

        playAgainBtn.gameObject.SetActive(false);
        backToMenuBtn.gameObject.SetActive(false);

        recipeShow.SetActive(true);
        followBtn.gameObject.SetActive(true);

        IEnumerator AlreadyStart()
        {
            yield return new WaitForSeconds(2);
            startText.enabled = false;
        }
    }

    void Update()
    {

    }

    public void FinishTutorial()
    {
        ShowTextFinishText();
    }

    public void ShowTextFinishText()
    {
        finishText.enabled = true;
        playAgainBtn.gameObject.SetActive(true);
        backToMenuBtn.gameObject.SetActive(true);
    }

    public void DisableButtonClick()
    {
        followBtn.interactable = false;
    }
}

