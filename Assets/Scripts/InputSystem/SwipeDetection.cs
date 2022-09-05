using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] //
    private float minDistance = 0.2f;
    [SerializeField] //
    private float  maxTime = 1;
    InputManager inputManager;
    Vector2 startPosition;
    float startTime;
    Vector2 endPosition;
    float endTime;

    void Update()
    {

    }
    
    void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    [SerializeField]
    public GameObject trail;
    private Coroutine coroutine;

    void SwipeStart(Vector2 position, float time)
    {
        startPosition = position; startTime = time;
        trail.SetActive(true);
        trail.transform.position = position;
        coroutine = StartCoroutine(Trail());
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }
    
    void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position; endTime = time;
        DetectSwipe();
    }

    void DetectSwipe()
    {
        Debug.Log("Start pos ="+ startPosition);
        Debug.Log("End pos ="+ endPosition);
        if(Vector3.Distance(startPosition,endPosition) >= minDistance && (endTime - startTime <= maxTime))
        {
            Debug.Log("Swipe detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction3 = endPosition - startPosition;
            Vector2 direction2 = new Vector2(direction3.x, direction3.y).normalized;
            SwipeDirection(direction2);
        }
    }

    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = 0.9f;
    //public RobotControllerScript playerScript;

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            //if (playerScript != null)
            //    playerScript.SwipeToJump(true);
            Debug.Log("Swipe UP");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            /*if (playerScript != null)
            {
                playerScript.SwipeToJump(false);
                playerScript.SwipeToWalk(0);
            }*/
            Debug.Log("Swipe DOWN");
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            //if (playerScript != null)
            //    playerScript.SwipeToWalk(-0.5f);
            Debug.Log("Swipe LEFT");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            //if (playerScript != null)
            //    playerScript.SwipeToWalk(0.5f);
            Debug.Log("Swipe RIGHT");
        }
    }
}
