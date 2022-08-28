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

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("back", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Idle", true);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("back", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("walkLeft", true);
            animator.SetBool("walkRight", false);
            animator.SetBool("back", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkRight", true);
            animator.SetBool("back", false);
        }
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        rigibody.velocity = direction * Time.deltaTime * speed;
    }
}
