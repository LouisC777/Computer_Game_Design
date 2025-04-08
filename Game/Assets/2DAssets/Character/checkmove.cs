using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkmove : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMoveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.Play("Walk_Up");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.Play("Walk_down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.Play("Walk_Left");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.Play("Walk_Right");
        }
    }
}
