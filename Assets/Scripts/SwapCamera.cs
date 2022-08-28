using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SwapCamera : MonoBehaviour
{
    public GameObject truckCam, startCam;
    public GameObject mainCam;
    private CinemachineBrain cinemachineBrain;
    public Button playBtn, tutorialBtn;

    void Start()
    {
        cinemachineBrain = mainCam.GetComponent<CinemachineBrain>();
        startCam.SetActive(true);
        truckCam.SetActive(false);
        StartCoroutine(FinishToTruckCam());

        playBtn.gameObject.SetActive(false);
        tutorialBtn.gameObject.SetActive(false);
        StartCoroutine(ShowButton());
    }

    IEnumerator FinishToTruckCam()
    {
        yield return new WaitForSeconds(2);
        startCam.SetActive(false);
        truckCam.SetActive(true);

    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(6);
        playBtn.gameObject.SetActive(true);
        tutorialBtn.gameObject.SetActive(true);
    }
}
