using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove123 : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rigid;
    float hengX;
    float zongY;
    Animator animation1;
    Vector2 Input1;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animation1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        hengX = Input.GetAxisRaw("Horizontal");
        zongY = Input.GetAxisRaw("Vertical");
        Input1 = new Vector2(hengX, zongY);
        rigid.linearVelocity = Input1*moveSpeed;
    }
    void Update()
    {
        shiftAnimation();
    }
    private void shiftAnimation()
    {
        animation1.SetBool("IsMoving", Input1 != Vector2.zero);
        if (Input1 != Vector2.zero)
        {
            animation1.SetFloat("MoveX", hengX);
            animation1.SetFloat("MoveY", zongY);
        }
    }
}
