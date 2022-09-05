using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rigibody;
    Animator animator;

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public string[] animationKeys = { "Idle", "walkLeft", "walkRight", "back"};

    void EnableAnimation(int index)
    {
        // เซ็ตแอนิเมชันเวลาที่ index เป็นค่า i
        for (int i = 0; i < animationKeys.Length; i++) animator.SetBool(animationKeys[i], index == i);
    }

    void HandleAnimator()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) EnableAnimation(0);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) EnableAnimation(1);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) EnableAnimation(2);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) EnableAnimation(3);

        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) )
        {
            EnableAnimation(0);
        }
    }

    void HandleDirection()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        rigibody.velocity = direction * Time.deltaTime * speed;
    }

    void Update()
    {
        HandleAnimator();
        HandleDirection();
    }
}